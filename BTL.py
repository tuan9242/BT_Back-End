# Nhập các thư viện cần thiết
import pandas as pd
import re
import nltk
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import accuracy_score, confusion_matrix, classification_report
import joblib

# Bước 1: Tải dữ liệu
# Bạn cần tải file 'spam.csv' từ Kaggle: https://www.kaggle.com/uciml/sms-spam-collection-dataset
print("Bước 1: Tải dữ liệu...")
du_lieu = pd.read_csv('spam.csv', encoding='latin-1')

# Hiển thị 5 dòng đầu tiên của dữ liệu
print("\nDữ liệu ban đầu:")
print(du_lieu.head())

# Bước 2: Tiền xử lý dữ liệu
print("\nBước 2: Tiền xử lý dữ liệu...")

# 2.1. Loại bỏ các cột không cần thiết
print("- Loại bỏ các cột không cần thiết...")
du_lieu = du_lieu[['v1', 'v2']]

# 2.2. Đổi tên cột để dễ hiểu
print("- Đổi tên cột...")
du_lieu.columns = ['nhan', 'tin_nhan']

# 2.3. Chuyển đổi nhãn thành số: spam -> 1, ham -> 0
print("- Chuyển đổi nhãn thành số...")
du_lieu['nhan'] = du_lieu['nhan'].map({'ham': 0, 'spam': 1})

# 2.4. Xử lý văn bản
print("- Xử lý văn bản...")
nltk.download('stopwords')
stemmer = PorterStemmer()
stop_words = set(stopwords.words('english'))

def tien_xu_ly_van_ban(van_ban):
    # Chuyển đổi chữ thường
    van_ban = van_ban.lower()
    # Loại bỏ ký tự đặc biệt và số
    van_ban = re.sub(r'[^a-zA-Z]', ' ', van_ban)
    # Loại bỏ stopwords và stemming
    van_ban = ' '.join([stemmer.stem(tu) for tu in van_ban.split() if tu not in stop_words])
    return van_ban

# Áp dụng hàm tiền xử lý cho cột 'tin_nhan'
du_lieu['tin_nhan'] = du_lieu['tin_nhan'].apply(tien_xu_ly_van_ban)

# Hiển thị 5 dòng đầu tiên sau khi tiền xử lý
print("\nDữ liệu sau khi tiền xử lý:")
print(du_lieu.head())

# Bước 3: Chia dữ liệu thành tập huấn luyện và tập kiểm tra
print("\nBước 3: Chia dữ liệu thành tập huấn luyện và tập kiểm tra...")
X = du_lieu['tin_nhan']  # Đặc trưng (features)
y = du_lieu['nhan']      # Nhãn (labels)

# Chia dữ liệu: 80% huấn luyện, 20% kiểm tra
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Hiển thị kích thước của các tập dữ liệu
print(f"- Kích thước tập huấn luyện: {X_train.shape}")
print(f"- Kích thước tập kiểm tra: {X_test.shape}")

# Bước 4: Vector hóa văn bản sử dụng TF-IDF
print("\nBước 4: Vector hóa văn bản sử dụng TF-IDF...")
vectorizer = TfidfVectorizer(max_features=5000)

# Huấn luyện vectorizer trên tập huấn luyện và biến đổi dữ liệu
print("- Huấn luyện vectorizer và biến đổi tập huấn luyện...")
X_train_vec = vectorizer.fit_transform(X_train)

# Biến đổi tập kiểm tra sử dụng vectorizer đã huấn luyện
print("- Biến đổi tập kiểm tra...")
X_test_vec = vectorizer.transform(X_test)

# Hiển thị kích thước của các vector
print(f"- Kích thước tập huấn luyện sau vector hóa: {X_train_vec.shape}")
print(f"- Kích thước tập kiểm tra sau vector hóa: {X_test_vec.shape}")

# Bước 5: Xây dựng mô hình Decision Tree
print("\nBước 5: Xây dựng mô hình Decision Tree...")
mo_hinh = DecisionTreeClassifier(random_state=42)

# Huấn luyện mô hình trên tập huấn luyện
print("- Huấn luyện mô hình...")
mo_hinh.fit(X_train_vec, y_train)

# Bước 6: Dự đoán trên tập kiểm tra
print("\nBước 6: Dự đoán trên tập kiểm tra...")
y_pred = mo_hinh.predict(X_test_vec)

# Hiển thị 5 dự đoán đầu tiên
print("- 5 dự đoán đầu tiên trên tập kiểm tra:")
print(y_pred[:5])

# Bước 7: Đánh giá mô hình
print("\nBước 7: Đánh giá mô hình...")

# Tính độ chính xác (Accuracy)
do_chinh_xac = accuracy_score(y_test, y_pred)
print(f"- Độ chính xác (Accuracy): {do_chinh_xac:.2f}")

# Ma trận nhầm lẫn (Confusion Matrix)
ma_tran_nham_lan = confusion_matrix(y_test, y_pred)
print("\n- Ma trận nhầm lẫn (Confusion Matrix):")
print(ma_tran_nham_lan)

# Báo cáo phân loại (Classification Report)
bao_cao_phan_loai = classification_report(y_test, y_pred)
print("\n- Báo cáo phân loại (Classification Report):")
print(bao_cao_phan_loai)

# Bước 8: Hàm dự đoán tin nhắn mới
def du_doan_spam(tin_nhan):
    # Tiền xử lý tin nhắn
    tin_nhan_da_xu_ly = tien_xu_ly_van_ban(tin_nhan)
    # Vector hóa tin nhắn
    tin_nhan_vec = vectorizer.transform([tin_nhan_da_xu_ly])
    # Dự đoán
    ket_qua = mo_hinh.predict(tin_nhan_vec)
    return "Spam" if ket_qua[0] == 1 else "Ham"

# Ví dụ dự đoán
print("\nBước 8: Dự đoán tin nhắn mới...")
tin_nhan_moi = "Chúc mừng! Bạn đã trúng thưởng 1 thẻ quà tặng Walmart trị giá $1000. Nhấp vào đây để nhận ngay."
print(f"- Tin nhắn cần dự đoán: '{tin_nhan_moi}'")
print(f"- Kết quả dự đoán: {du_doan_spam(tin_nhan_moi)}")