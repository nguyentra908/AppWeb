-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th3 28, 2020 lúc 03:49 PM
-- Phiên bản máy phục vụ: 10.4.6-MariaDB
-- Phiên bản PHP: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `laravel`
--

DELIMITER $$
--
-- Thủ tục
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `TAOKH` (`VTENTK` VARCHAR(20), `VPASS` VARCHAR(20), `VTENKH` VARCHAR(30), `VDIACHI` VARCHAR(100), `VSDT` CHAR(10), `VEMAIL` VARCHAR(50))  BEGIN 
/*Code*/ INSERT INTO taikhoan VALUES(VTENTK,VPASS,'khach'); INSERT INTO khachhang VALUES(NULL,VTENKH,VDIACHI,VSDT,VEMAIL,TENTK); END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `anh`
--

CREATE TABLE `anh` (
  `MASP` int(10) UNSIGNED NOT NULL,
  `LINK` varchar(255) COLLATE utf8_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitiethoadon`
--

CREATE TABLE `chitiethoadon` (
  `MAHD` int(10) UNSIGNED NOT NULL,
  `MASP` int(10) UNSIGNED NOT NULL,
  `THANHTIEN` int(11) DEFAULT NULL,
  `SOLUONG` int(11) DEFAULT NULL,
  `GIA` int(30) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `chitiethoadon`
--

INSERT INTO `chitiethoadon` (`MAHD`, `MASP`, `THANHTIEN`, `SOLUONG`, `GIA`, `created_at`, `updated_at`) VALUES
(6, 1, NULL, 1, 5000000, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
(6, 2, NULL, 2, 1000000, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
(10, 1, NULL, 2, 5000000, '2019-12-20 21:08:15', '2019-12-20 21:08:15'),
(11, 2, NULL, 2, 1000000, '2019-12-21 22:38:34', '2019-12-21 22:38:34');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hang`
--

CREATE TABLE `hang` (
  `MAHANG` int(11) NOT NULL,
  `TENHANG` varchar(30) COLLATE utf8_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `hang`
--

INSERT INTO `hang` (`MAHANG`, `TENHANG`) VALUES
(1, 'Iphone'),
(2, 'SamSung '),
(3, 'Xiaomi'),
(4, 'Oppo'),
(5, 'Nokia'),
(6, 'Realmi'),
(7, 'Sony'),
(8, 'LG'),
(9, 'Lenovo');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hoadon`
--

CREATE TABLE `hoadon` (
  `MAHD` int(10) UNSIGNED NOT NULL,
  `NGAYHD` date NOT NULL,
  `TONGTIEN` int(11) NOT NULL,
  `IDKH` int(10) UNSIGNED NOT NULL,
  `GHICHU` text COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `TINHTRANG` varchar(50) COLLATE utf8_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `hoadon`
--

INSERT INTO `hoadon` (`MAHD`, `NGAYHD`, `TONGTIEN`, `IDKH`, `GHICHU`, `created_at`, `updated_at`, `TINHTRANG`) VALUES
(6, '2019-12-17', 7000000, 10, 'ok', '2019-12-17 06:37:02', '2019-12-17 06:37:02', 'bom'),
(7, '2019-12-21', 10000000, 11, 'gfbfx', '2019-12-21 04:03:53', '2019-12-21 04:03:53', ''),
(8, '2019-12-21', 10000000, 12, 'gfbfx', '2019-12-21 04:04:11', '2019-12-21 04:04:11', ''),
(9, '2019-12-21', 10000000, 13, 'gfbfx', '2019-12-21 04:04:29', '2019-12-21 04:04:29', ''),
(10, '2019-12-21', 10000000, 15, 'gfbfx', '2019-12-21 04:08:15', '2019-12-21 04:08:15', 'chưa giao'),
(11, '2019-12-22', 2000000, 18, 'ok', '2019-12-22 05:38:34', '2019-12-22 05:38:34', 'huy');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE `khachhang` (
  `ID` int(10) UNSIGNED NOT NULL,
  `TEN` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `EMAIL` varchar(255) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `DIACHI` varchar(255) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `SDT` varchar(10) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `GHICHU` text COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `khachhang`
--

INSERT INTO `khachhang` (`ID`, `TEN`, `EMAIL`, `DIACHI`, `SDT`, `GHICHU`, `created_at`, `updated_at`) VALUES
(10, 'nguyen my linh', 'kimthao581999@gmail.com', 'khu b', '0377842878', NULL, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
(11, 'nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:03:53', '2019-12-20 21:03:53'),
(12, 'nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:04:11', '2019-12-20 21:04:11'),
(13, 'nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:04:29', '2019-12-20 21:04:29'),
(14, 'nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:07:00', '2019-12-20 21:07:00'),
(15, 'nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:08:15', '2019-12-20 21:08:15'),
(16, 'nguyen', 'nguyen@gmail.com', 'ngày 03', '1234567890', NULL, '2019-12-21 22:34:02', '2019-12-21 22:34:02'),
(17, 'nguyen', 'nguyen@gmail.com', 'ngày 03', '1234567890', NULL, '2019-12-21 22:36:29', '2019-12-21 22:36:29'),
(18, 'nguyen', 'nguyen@gmail.com', 'ngày 03', '1234567890', NULL, '2019-12-21 22:38:34', '2019-12-21 22:38:34');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `magiamgia`
--

CREATE TABLE `magiamgia` (
  `MAGIAMGIA` varchar(10) COLLATE utf8_vietnamese_ci NOT NULL,
  `MASP` int(10) UNSIGNED NOT NULL,
  `PHANTRAM` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE `sanpham` (
  `MASP` int(10) UNSIGNED NOT NULL,
  `TENSP` varchar(30) COLLATE utf8_vietnamese_ci NOT NULL,
  `HANG` int(11) NOT NULL,
  `MOTA` varchar(200) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `NAMSX` date DEFAULT NULL,
  `GIA` int(11) DEFAULT NULL,
  `GIAKHUYENMAI` int(11) DEFAULT NULL,
  `ANHDAIDIEN` varchar(150) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `MANHINH` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `CAMERATRUOC` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `CAMERASAU` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `RAM` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `BONHOTRONG` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `CPU` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `GPU` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `PIN` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `OS` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `SIM` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`MASP`, `TENSP`, `HANG`, `MOTA`, `NAMSX`, `GIA`, `GIAKHUYENMAI`, `ANHDAIDIEN`, `MANHINH`, `CAMERATRUOC`, `CAMERASAU`, `RAM`, `BONHOTRONG`, `CPU`, `GPU`, `PIN`, `OS`, `SIM`) VALUES
(1, 'Dien thoai di dong thong minh', 1, 'd', NULL, 10000000, 5000000, '6s-plus.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 'Dien thoai di dong thong minh', 2, NULL, NULL, 1000000, NULL, '6s-plus-8.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, 'Dien thoai di dong thong minh', 1, NULL, NULL, 1000000, NULL, '11.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'Dien thoai di dong thong minh', 2, NULL, NULL, 1000000, NULL, '11-den.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'Điện thoại thông minh', 1, NULL, NULL, 1000000, NULL, '11-do.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, 'Điện thoại thông minh', 2, NULL, NULL, 1000000, NULL, '11-pro-max-xam.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(7, 'Điện thoại thông minh', 6, NULL, NULL, 1000000, NULL, 'xr.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(8, 'Điện thoại thông minh', 4, NULL, NULL, 1000000, NULL, '11-pro-max-bac.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(9, 'Điện thoại thông minh', 3, NULL, NULL, 1000000, NULL, '11-vang.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(10, 'Điện thoại thông minh', 1, NULL, NULL, 1000000, NULL, '11-pro-max-vang.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(11, 'Điện thoại thông minh', 5, NULL, NULL, 1000000, NULL, 'xr-den.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(12, 'Điện thoại thông minh', 3, NULL, NULL, 1000000, NULL, 'xr-xanh.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, 'Điện thoại thông minh', 7, NULL, NULL, 1000000, NULL, 'xr-vang.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(14, 'Điện thoại thông minh', 2, NULL, NULL, 1000000, NULL, 'xr-trang.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, 'Điện thoại thông minh', 1, NULL, NULL, 1000000, NULL, 'xr-nau.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(16, 'Điện thoại thông minh', 4, NULL, NULL, 1000000, NULL, 'xs-max.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(17, 'Điện thoại thông minh', 2, NULL, NULL, 1000000, NULL, 'xs-max-2.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(18, 'Điện thoại thông minh', 3, NULL, NULL, 1000000, NULL, 'xs-max-1.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(19, 'Điện thoại thông minh', 1, NULL, NULL, 1000000, NULL, 'xs-max-4.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, 'Điện thoại thông minh', 8, NULL, NULL, 1000000, NULL, '6s-plus-7.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(21, 'Điện thoại thông minh', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(27, 'dien thoai', 1, 'ok', NULL, 1000000, 90000, NULL, '70in', '30', '50', '20', NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE `taikhoan` (
  `TENTK` varchar(20) COLLATE utf8_vietnamese_ci NOT NULL,
  `PASS` varchar(100) COLLATE utf8_vietnamese_ci NOT NULL,
  `QUYEN` varchar(20) COLLATE utf8_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO `taikhoan` (`TENTK`, `PASS`, `QUYEN`) VALUES
('taikhoan1', '123', 'admin'),
('taikhoan10', '123', 'khach'),
('taikhoan2', '123', 'admin'),
('taikhoan3', '123', 'khach'),
('taikhoan4', '123', 'khach'),
('taikhoan5', '123', 'khach'),
('taikhoan6', '123', 'khach'),
('taikhoan7', '123', 'admin'),
('taikhoan8', '123', 'khach'),
('taikhoan9', '123', 'khach');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `ID` int(10) UNSIGNED NOT NULL,
  `FULL_NAME` varchar(30) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `ROLE` varchar(30) COLLATE utf8_vietnamese_ci NOT NULL DEFAULT 'khach',
  `DIACHI` varchar(100) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `SDT` char(10) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `password` varchar(255) COLLATE utf8_vietnamese_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`ID`, `FULL_NAME`, `ROLE`, `DIACHI`, `SDT`, `email`, `password`, `remember_token`, `created_at`, `updated_at`) VALUES
(12, 'nguyễn kim thảo', 'khach', 'khu b', '0377842878', 'kimthao581999@gmail.com', '$2y$10$TBXBMvPwjQJrfdYsjzoez./Ihk90G5rodeN6qaTGb1Hz3l8JOp.Ji', NULL, '2019-12-07 23:39:19', '2019-12-07 23:39:19'),
(13, 'Quỳnh', 'khach', '3', '1140000000', 'nguyen@gmail.com', '$2y$10$uDQ1E3eQIcRGCDuRz2cW..bZpdi1.7PTS8iHiU4M4fBK3eoZK5lfy', NULL, '2019-12-20 20:54:53', '2019-12-20 20:54:53');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `anh`
--
ALTER TABLE `anh`
  ADD PRIMARY KEY (`MASP`,`LINK`);

--
-- Chỉ mục cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD PRIMARY KEY (`MAHD`,`MASP`) USING BTREE,
  ADD KEY `FK_CTHD_SP` (`MASP`),
  ADD KEY `FK_CTHD_HD` (`MAHD`);

--
-- Chỉ mục cho bảng `hang`
--
ALTER TABLE `hang`
  ADD PRIMARY KEY (`MAHANG`);

--
-- Chỉ mục cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MAHD`),
  ADD KEY `FK_HD_KH` (`IDKH`);

--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`ID`);

--
-- Chỉ mục cho bảng `magiamgia`
--
ALTER TABLE `magiamgia`
  ADD PRIMARY KEY (`MAGIAMGIA`),
  ADD KEY `FK_GIAMGIA_SP` (`MASP`);

--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MASP`),
  ADD KEY `FK_SP_HANG` (`HANG`);

--
-- Chỉ mục cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`TENTK`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `EMAIL_UNI` (`email`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `hang`
--
ALTER TABLE `hang`
  MODIFY `MAHANG` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `MAHD` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MASP` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `anh`
--
ALTER TABLE `anh`
  ADD CONSTRAINT `FK_ANH_KH` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`);

--
-- Các ràng buộc cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD CONSTRAINT `FK_CTHD_HD` FOREIGN KEY (`MAHD`) REFERENCES `hoadon` (`MAHD`),
  ADD CONSTRAINT `FK_CTHD_SP` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`);

--
-- Các ràng buộc cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `FK_HD_KH` FOREIGN KEY (`IDKH`) REFERENCES `khachhang` (`ID`);

--
-- Các ràng buộc cho bảng `magiamgia`
--
ALTER TABLE `magiamgia`
  ADD CONSTRAINT `FK_GIAMGIA_SP` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`);

--
-- Các ràng buộc cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD CONSTRAINT `FK_SP_HANG` FOREIGN KEY (`HANG`) REFERENCES `hang` (`MAHANG`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
