Xóa nhân viên -> kiểm tra nhân viên có đang được phân công không..
Thêm nhân viên -> kiểm tra trùng 
					Kiểm tra mã nhân viên
Đăng ký -> chỉ admin được đăng ký
Thêm -> chỉnh sửa phân công
Thêm xóa sửa loại thực đơn:
 - Ràng buộc: có chứa thực đơn thì không đc xóa.
 - Ràng buộc: trùng hoặc start with (thực đơn + loại thực đơn)
Update DB:
Mã chi tiết hóa đơn (identity)
tình trạng hóa đơn (0:chưa thanh toán ; 1: đã thanh toán)
Tình trạng bàn(0: trống ; 1: có người)
Điều kiện bàn:
Chọn bàn(Bàn trống) -> Chọn loại thực đơn + nvien (Save with Hóa đơn)
Điều kiện xóa món và gọi món
tiến
