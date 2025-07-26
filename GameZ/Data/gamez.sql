-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th3 23, 2025 lúc 04:02 PM
-- Phiên bản máy phục vụ: 10.4.27-MariaDB
-- Phiên bản PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `gamez`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cart`
--

CREATE TABLE `cart` (
  `cart_id` varchar(5) NOT NULL,
  `time_add` date NOT NULL,
  `game_id` varchar(8) NOT NULL,
  `user_id` varchar(10) NOT NULL,
  `price_at_add_time` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories`
--

CREATE TABLE `categories` (
  `categories_id` varchar(5) NOT NULL,
  `categories_name` varchar(50) NOT NULL,
  `type_id` varchar(5) NOT NULL,
  `img_url` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `categories`
--

INSERT INTO `categories` (`categories_id`, `categories_name`, `type_id`, `img_url`) VALUES
('C1', 'Hành động', 'T1', 'img/theloai/tlhanhdong.png'),
('C10', 'Theo lượt', 'T1', 'img/theloai/tltheoluot.png'),
('C11', 'Giải đố', 'T1', 'img/theloai/tlgiaido.png'),
('C12', 'Cốt truyện', 'T1', 'img/theloai/tlcottruyen.png'),
('C13', 'Bài & Cờ', 'T1', ''),
('C14', 'Khoa học viễn tưởng', 'T2', 'img/theloai/tlkhoahocvt.png'),
('C15', 'Kinh dị', 'T2', 'img/theloai/tlkinhdi.png'),
('C16', 'Thế giới mở', 'T2', 'img/theloai/tlthegioimo.png'),
('C17', 'Sinh tồn', 'T2', 'img/theloai/tlsinhton.png'),
('C18', 'Miễn phí', 'T3', 'img/theloai/tlmienphi.png'),
('C19', 'Có tính phí', 'T3', ''),
('C2', 'Nhập vai', 'T1', 'img/theloai/tlnhapvai.png'),
('C20', 'Chơi đơn', 'T4', ''),
('C21', 'Chơi nhiều người', 'T4', ''),
('C22', 'Mạng cục bộ', 'T4', ''),
('C3', 'Chiến thuật', 'T1', ''),
('C4', 'Phiêu lưu', 'T1', 'img/theloai/tlphieuluu.png'),
('C5', 'Mô phỏng', 'T1', 'img/theloai/tlmophong.png'),
('C6', 'Bắn súng', 'T1', ''),
('C7', 'Âm nhạc', 'T1', ''),
('C8', 'Thể thao', 'T1', 'img/theloai/tlthethao.png'),
('C9', 'Câu cá', 'T1', '');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories_game`
--

CREATE TABLE `categories_game` (
  `categoriesID` varchar(5) NOT NULL,
  `gameID` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `categories_game`
--

INSERT INTO `categories_game` (`categoriesID`, `gameID`) VALUES
('C1', 'G1'),
('C6', 'G1'),
('C16', 'G1'),
('C21', 'G1'),
('C19', 'G1'),
('C2', 'G2'),
('C4', 'G2'),
('C16', 'G2'),
('C12', 'G2'),
('C19', 'G2'),
('C3', 'G3'),
('C10', 'G3'),
('C21', 'G3'),
('C19', 'G3'),
('C4', 'G4'),
('C16', 'G4'),
('C12', 'G4'),
('C19', 'G4'),
('C5', 'G5'),
('C3', 'G5'),
('C19', 'G5'),
('C6', 'G6'),
('C17', 'G6'),
('C21', 'G6'),
('C18', 'G6'),
('C7', 'G7'),
('C20', 'G7'),
('C19', 'G7'),
('C8', 'G8'),
('C21', 'G8'),
('C19', 'G8'),
('C9', 'G9'),
('C18', 'G9'),
('C21', 'G9'),
('C3', 'G10'),
('C10', 'G10'),
('C19', 'G10'),
('C11', 'G11'),
('C20', 'G11'),
('C21', 'G11'),
('C19', 'G11'),
('C13', 'G12'),
('C21', 'G12'),
('C19', 'G12'),
('C6', 'G13'),
('C15', 'G13'),
('C4', 'G13'),
('C12', 'G13'),
('C2', 'G14'),
('C4', 'G14'),
('C12', 'G14'),
('C16', 'G14'),
('C5', 'G15'),
('C16', 'G15'),
('C17', 'G15'),
('C9', 'G15'),
('C19', 'G13'),
('C19', 'G14'),
('C19', 'G15');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `developers`
--

CREATE TABLE `developers` (
  `developers_id` varchar(5) NOT NULL,
  `developers_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `developers`
--

INSERT INTO `developers` (`developers_id`, `developers_name`) VALUES
('D1', 'Rockstar North'),
('D10', 'Firaxis Games'),
('D11', 'Valve'),
('D12', 'Chess.com Team'),
('D13', 'Capcom'),
('D14', 'Team Cherry'),
('D15', 'ConcernedApe'),
('D2', 'CD Projekt Red'),
('D3', 'Relic Entertainment'),
('D4', 'Nintendo EPD'),
('D5', 'Maxis'),
('D6', 'Infinity Ward'),
('D7', 'Beat Games'),
('D8', 'EA Vancouver'),
('D9', 'Fishing Planet LLC');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `discounts`
--

CREATE TABLE `discounts` (
  `discount_id` varchar(5) NOT NULL,
  `discount_name` varchar(1000) NOT NULL,
  `discount_type` enum('Phần trăm','Giảm giá cố định') NOT NULL,
  `discount_value` float NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `discounts`
--

INSERT INTO `discounts` (`discount_id`, `discount_name`, `discount_type`, `discount_value`, `start_date`, `end_date`) VALUES
('D1', 'Giảm 50% Tết 2025', 'Phần trăm', 50, '2025-01-25', '2025-02-10'),
('D2', 'Giảm 100k cho game trên 500k', 'Giảm giá cố định', 100000, '2025-03-01', '2026-03-31'),
('D3', 'Sale tháng', 'Phần trăm', 40, '2025-03-01', '2025-03-31');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `game`
--

CREATE TABLE `game` (
  `game_id` varchar(8) NOT NULL,
  `game_name` varchar(100) NOT NULL,
  `realse_date` date NOT NULL,
  `publisherID` varchar(5) NOT NULL,
  `developerID` varchar(5) NOT NULL,
  `game_details` varchar(10000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `game`
--

INSERT INTO `game` (`game_id`, `game_name`, `realse_date`, `publisherID`, `developerID`, `game_details`) VALUES
('G1', 'GTA V', '2013-09-17', 'P1', 'D1', 'GTA V là một trò chơi thế giới mở mang tính biểu tượng, đưa người chơi vào thành phố Los Santos rộng lớn. Bạn có thể hoàn thành nhiệm vụ chính, tham gia các hoạt động bên lề như đua xe, cướp ngân hàng, hoặc đơn giản là khám phá thế giới mở phong phú với hàng loạt phương tiện, vũ khí và nhân vật thú vị.'),
('G10', 'XCOM 2', '2016-02-05', 'P10', 'D10', 'XCOM 2 là game chiến thuật theo lượt, đưa người chơi vào cuộc chiến chống lại các thế lực ngoài hành tinh đang xâm chiếm Trái Đất. Với cơ chế chiến đấu theo lượt đặc sắc, khả năng nâng cấp quân đội, và cốt truyện hấp dẫn, trò chơi thử thách kỹ năng chiến thuật của người chơi.'),
('G11', 'Portal 2', '2011-04-19', 'P11', 'D11', 'Portal 2 là một trò chơi giải đố nổi tiếng của Valve, trong đó người chơi sử dụng súng tạo cổng không gian để vượt qua các thử thách vật lý đầy sáng tạo. Trò chơi có cốt truyện hài hước, nhân vật đáng nhớ như GLaDOS, và chế độ co-op độc đáo.'),
('G12', 'UNO', '2016-12-08', 'P12', 'D12', 'UNO là một trò chơi bài cổ điển, nơi người chơi cố gắng loại bỏ hết bài trên tay bằng cách sử dụng các lá bài đặc biệt như Draw Two, Reverse, và Skip. Trò chơi mang tính giải trí cao, phù hợp để chơi cùng bạn bè và gia đình.'),
('G13', 'Resident Evil 4 Remake', '2023-03-24', 'P13', 'D13', 'Resident Evil 4 Remake là phiên bản làm lại của tựa game kinh điển năm 2005, mang đến trải nghiệm bắn súng sinh tồn căng thẳng với đồ họa cải tiến, cơ chế chiến đấu mượt mà và cốt truyện được mở rộng. Người chơi sẽ vào vai Leon S. Kennedy, một đặc vụ được cử đi giải cứu con gái của Tổng thống Mỹ khỏi một giáo phái bí ẩn. Trò chơi có hệ thống chiến đấu linh hoạt, kẻ thù thông minh hơn và môi trường có thể tương tác, tạo nên một trải nghiệm đáng nhớ cho người hâm mộ dòng game kinh dị sinh tồn.'),
('G14', 'Hollow Knight', '2017-02-24', 'P14', 'D14', 'Hollow Knight là một trò chơi phiêu lưu hành động 2D lấy cảm hứng từ thể loại Metroidvania, đưa người chơi vào một thế giới ngầm rộng lớn có tên là Hallownest. Người chơi sẽ vào vai một chiến binh bí ẩn khám phá tàn tích của một vương quốc cổ đại, chiến đấu với những sinh vật nguy hiểm và giải mã bí ẩn của vùng đất này. Trò chơi sở hữu đồ họa vẽ tay tuyệt đẹp, nhạc nền sâu lắng và cơ chế chiến đấu đầy thử thách, mang lại trải nghiệm tuyệt vời cho những ai yêu thích game platforming và khám phá.'),
('G15', 'Stardew Valley', '2016-02-26', 'P15', 'D15', 'Stardew Valley là một trò chơi mô phỏng nông trại pha trộn yếu tố nhập vai, nơi người chơi có thể trồng trọt, chăn nuôi, khai thác mỏ, câu cá, tham gia vào các sự kiện của thị trấn và xây dựng mối quan hệ với các cư dân địa phương. Với phong cách đồ họa pixel cổ điển nhưng đầy màu sắc, trò chơi mang lại cảm giác thư giãn và hấp dẫn. Người chơi có thể tự do phát triển trang trại theo ý muốn, khám phá các hang động chứa quái vật và kho báu, cũng như kết hôn và xây dựng gia đình trong thế giới mở sinh động này.'),
('G2', 'The Witcher 3', '2015-05-19', 'P2', 'D2', 'The Witcher 3: Wild Hunt là một game nhập vai hành động có cốt truyện sâu sắc, đưa người chơi vào vai Geralt of Rivia - một thợ săn quái vật chuyên nghiệp. Thế giới mở rộng lớn với các vùng đất như Velen, Novigrad, và Skellige mang đến hàng trăm nhiệm vụ phụ, hệ thống chiến đấu phong phú, và nhiều kết thúc khác nhau tùy thuộc vào lựa chọn của người chơi.'),
('G3', 'Age of Empires IV', '2021-10-28', 'P3', 'D3', 'Age of Empires IV là phần tiếp theo của series game chiến thuật thời gian thực huyền thoại. Người chơi sẽ điều khiển các nền văn minh lịch sử như Anh, Pháp, Trung Quốc, và Đế chế Mông Cổ để xây dựng đế chế của mình, thu thập tài nguyên, huấn luyện quân đội, và tham gia các trận chiến lịch sử hấp dẫn.'),
('G4', 'Zelda: BOTW', '2017-03-03', 'P4', 'D4', 'The Legend of Zelda: Breath of the Wild là một game phiêu lưu hành động thế giới mở, nơi người chơi vào vai Link trong hành trình đánh bại Calamity Ganon và cứu vương quốc Hyrule. Trò chơi nổi bật với hệ thống vật lý chân thực, khả năng tương tác cao, và thế giới rộng lớn cho phép người chơi tự do khám phá.'),
('G5', 'SimCity', '2013-03-05', 'P5', 'D5', 'SimCity là game mô phỏng xây dựng thành phố, nơi người chơi có thể thiết kế và quản lý một đô thị từ con số 0. Bạn sẽ cần cân bằng tài nguyên, kiểm soát giao thông, thu thuế, và phát triển cơ sở hạ tầng để tạo ra một thành phố phát triển mạnh mẽ.'),
('G6', 'Call of Duty: Warzone', '2020-03-10', 'P6', 'D6', 'Call of Duty: Warzone là một trò chơi bắn súng sinh tồn miễn phí, đưa 150 người chơi vào một chiến trường khổng lồ để chiến đấu đến cùng. Với nhiều chế độ như Battle Royale, Plunder, và Resurgence, Warzone mang đến trải nghiệm FPS kịch tính và có chiều sâu.'),
('G7', 'Beat Saber', '2018-05-01', 'P7', 'D7', 'Beat Saber là một game âm nhạc thực tế ảo, nơi người chơi sử dụng hai thanh ánh sáng để chém các khối theo nhịp điệu của bài hát. Trò chơi nổi bật với đồ họa neon sống động, các bài hát đa dạng, và khả năng tạo map riêng cho cộng đồng.'),
('G8', 'FIFA 22', '2021-10-01', 'P8', 'D8', 'FIFA 22 là game bóng đá nổi tiếng của EA Sports, mang đến trải nghiệm thực tế với đồ họa chân thực, cơ chế HyperMotion AI mới, và nhiều chế độ chơi hấp dẫn như Career Mode, Ultimate Team, và VOLTA Football.'),
('G9', 'Fishing Planet', '2015-08-11', 'P9', 'D9', 'Fishing Planet là một game mô phỏng câu cá chân thực, nơi người chơi có thể trải nghiệm nhiều địa điểm câu cá trên khắp thế giới, sử dụng các loại cần câu, mồi câu khác nhau để bắt nhiều loài cá độc đáo.');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `game_developers`
--

CREATE TABLE `game_developers` (
  `game_id` varchar(8) NOT NULL,
  `developers_id` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `game_developers`
--

INSERT INTO `game_developers` (`game_id`, `developers_id`) VALUES
('G1', 'D1'),
('G2', 'D2'),
('G3', 'D3'),
('G4', 'D4'),
('G5', 'D5'),
('G6', 'D6'),
('G7', 'D7'),
('G8', 'D8'),
('G9', 'D9'),
('G10', 'D10'),
('G11', 'D11'),
('G12', 'D12'),
('G13', 'D13'),
('G14', 'D14'),
('G15', 'D15');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `game_discounts`
--

CREATE TABLE `game_discounts` (
  `game_id` varchar(8) NOT NULL,
  `discount_id` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `game_discounts`
--

INSERT INTO `game_discounts` (`game_id`, `discount_id`) VALUES
('G3', 'D2'),
('G4', 'D2'),
('G8', 'D2'),
('G13', 'D2'),
('G1', 'D1'),
('G2', 'D1'),
('G5', 'D1'),
('G7', 'D1'),
('G10', 'D3'),
('G12', 'D1'),
('G11', 'D3'),
('G14', 'D3'),
('G15', 'D3');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `game_img`
--

CREATE TABLE `game_img` (
  `img_id` varchar(5) NOT NULL,
  `img_url` varchar(100) NOT NULL,
  `game_id` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `game_img`
--

INSERT INTO `game_img` (`img_id`, `img_url`, `game_id`) VALUES
('I1', 'img/GTA_V/anh1.png', 'G1'),
('I10', 'img/Age_of_Empires_IV/anh10.png', 'G3'),
('I11', 'img/Age_of_Empires_IV/anh11.png', 'G3'),
('I12', 'img/Age_of_Empires_IV/anh12.png', 'G3'),
('I13', 'img/Zelda_BOTW/anh13.png', 'G4'),
('I14', 'img/Zelda_BOTW/anh14.png', 'G4'),
('I15', 'img/Zelda_BOTW/anh15.png', 'G4'),
('I16', 'img/Zelda_BOTW/anh16.png', 'G4'),
('I17', 'img/SimCity/anh17.png', 'G5'),
('I18', 'img/SimCity/anh18.png', 'G5'),
('I19', 'img/SimCity/anh19.png', 'G5'),
('I2', 'img/GTA_V/anh2.png', 'G1'),
('I20', 'img/SimCity/anh20.png', 'G5'),
('I21', 'img/Call_of_Duty_Warzone/anh21.png', 'G6'),
('I22', 'img/Call_of_Duty_Warzone/anh22.png', 'G6'),
('I23', 'img/Call_of_Duty_Warzone/anh23.png', 'G6'),
('I24', 'img/Call_of_Duty_Warzone/anh24.png', 'G6'),
('I25', 'img/Beat_Saber/anh25.png', 'G7'),
('I26', 'img/Beat_Saber/anh26.png', 'G7'),
('I27', 'img/Beat_Saber/anh27.png', 'G7'),
('I28', 'img/Beat_Saber/anh28.png', 'G7'),
('I29', 'img/FIFA_22/anh29.png', 'G8'),
('I3', 'img/GTA_V/anh3.png', 'G1'),
('I30', 'img/FIFA_22/anh30.png', 'G8'),
('I31', 'img/FIFA_22/anh31.png', 'G8'),
('I32', 'img/FIFA_22/anh32.png', 'G8'),
('I33', 'img/Fishing_Planet/anh33.png', 'G9'),
('I34', 'img/Fishing_Planet/anh34.png', 'G9'),
('I35', 'img/Fishing_Planet/anh35.png', 'G9'),
('I36', 'img/Fishing_Planet/anh36.png', 'G9'),
('I37', 'img/XCOM_2/anh37.png', 'G10'),
('I38', 'img/XCOM_2/anh38.png', 'G10'),
('I39', 'img/XCOM_2/anh39.png', 'G10'),
('I4', 'img/GTA_V/anh4.png', 'G1'),
('I40', 'img/XCOM_2/anh40.png', 'G10'),
('I41', 'img/Portal_2/anh41.png', 'G11'),
('I42', 'img/Portal_2/anh42.png', 'G11'),
('I43', 'img/Portal_2/anh43.png', 'G11'),
('I44', 'img/Portal_2/anh44.png', 'G11'),
('I45', 'img/UNO/anh45.png', 'G12'),
('I46', 'img/UNO/anh46.png', 'G12'),
('I47', 'img/UNO/anh47.png', 'G12'),
('I48', 'img/UNO/anh48.png', 'G12'),
('I49', 'img/Resident_Evil_4_Remake/anh49.png', 'G13'),
('I5', 'img/The_Witcher_3/anh5.png', 'G2'),
('I50', 'img/Resident_Evil_4_Remake/anh50.png', 'G13'),
('I51', 'img/Resident_Evil_4_Remake/anh51.png', 'G13'),
('I52', 'img/Resident_Evil_4_Remake/anh52.png', 'G13'),
('I53', 'img/Hollow_Knight/anh53.png', 'G14'),
('I54', 'img/Hollow_Knight/anh54.png', 'G14'),
('I55', 'img/Hollow_Knight/anh55.png', 'G14'),
('I56', 'img/Hollow_Knight/anh56.png', 'G14'),
('I57', 'img/Stardew_Valley/anh57.png', 'G15'),
('I58', 'img/Stardew_Valley/anh58.png', 'G15'),
('I59', 'img/Stardew_Valley/anh59.png', 'G15'),
('I6', 'img/The_Witcher_3/anh6.png', 'G2'),
('I60', 'img/Stardew_Valley/anh60.png', 'G15'),
('I7', 'img/The_Witcher_3/anh7.png', 'G2'),
('I8', 'img/The_Witcher_3/anh8.png', 'G2'),
('I9', 'img/Age_of_Empires_IV/anh9.png', 'G3');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `game_price`
--

CREATE TABLE `game_price` (
  `price_id` varchar(5) NOT NULL,
  `game_id` varchar(8) NOT NULL,
  `price_value` float NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `game_price`
--

INSERT INTO `game_price` (`price_id`, `game_id`, `price_value`, `start_date`, `end_date`) VALUES
('P1', 'G1', 499000, '2024-01-01', '2024-12-31'),
('P10', 'G10', 459000, '2024-01-01', '2024-12-31'),
('P11', 'G11', 249000, '2024-01-01', '2024-12-31'),
('P12', 'G12', 149000, '2024-01-01', '2024-12-31'),
('P13', 'G13', 1499000, '2023-03-24', '9999-12-31'),
('P14', 'G14', 165000, '2017-02-24', '9999-12-31'),
('P15', 'G15', 165000, '2016-02-26', '9999-12-31'),
('P2', 'G2', 399000, '2024-01-01', '2024-12-31'),
('P3', 'G3', 599000, '2024-01-01', '2024-12-31'),
('P4', 'G4', 999000, '2024-01-01', '2024-12-31'),
('P5', 'G5', 199000, '2024-01-01', '2024-12-31'),
('P6', 'G6', 0, '2024-01-01', '2024-12-31'),
('P7', 'G7', 299000, '2024-01-01', '2024-12-31'),
('P8', 'G8', 799000, '2024-01-01', '2024-12-31'),
('P9', 'G9', 0, '2024-01-01', '2024-12-31');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `news`
--

CREATE TABLE `news` (
  `news_id` varchar(10) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `content` text NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `author` varchar(100) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `news`
--

INSERT INTO `news` (`news_id`, `title`, `description`, `content`, `image`, `author`, `created_at`) VALUES
('N1', 'Hogwarts Legacy trên PS5: Những suy nghĩ của tôi.', 'Giống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\n\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\n\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\n\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\n11/03/2025 11:36 PC/Console\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\n\n\n\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\n\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\n\nTrải nghiệm Hogwarts sống động nhất từng có\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\n\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\n\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\n\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\n11/03/2025 11:36 PC/Console\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\n\n\n\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\n\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\n\nTrải nghiệm Hogwarts sống động nhất từng có\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\n\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\n\n\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\n\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\n\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\n\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\n\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\n\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\n\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh1.png', 'Mọt Hóng', '2025-03-11 10:53:31'),
('N2', 'Black Myth: Wukong gặp kiếp nạn tại The Game Awards', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh2.png', '\r\nMọt Hóng', '2025-03-11 03:53:31'),
('N3', 'PlayStation 5 Pro lộ cấu hình \"khủng\" trước ngày ra mắt!', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh3.png', '\r\nMọt Hóng', '2025-03-11 03:53:31'),
('N4', 'Half-Life 3 \"phiên bản fanmade\" sắp ra mắt, game thủ 8x rớt nước mắt!', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh4.png', '\r\nMọt Tự Kỷ', '2025-03-11 03:53:31'),
('N5', 'Team Flash ra mắt bản đồ game trốn tìm cực đỉnh trên Fortnite', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh5.png', '\r\nBất Chính Đại Hiệp', '2025-03-11 03:53:31');
INSERT INTO `news` (`news_id`, `title`, `description`, `content`, `image`, `author`, `created_at`) VALUES
('N6', 'Những điểm khiến Galaxy S25 Ultra ăn đứt \"tiền bối\" Galaxy S24 Ultra ở Mode Gaming!', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh6.png', '\r\nMọt Hóng', '2025-03-11 03:53:31'),
('N7', 'Ra mắt fanpage FC Online Esports Việt Nam - Điểm đến mới cho cộng đồng FC Online', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh7.png', '\r\nMọt Hóng', '2025-03-11 03:53:31'),
('N8', 'Thông cáo báo chí lễ ký kết hợp tác giữa VTVCAB và VNGGAMES', '\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.', 'Khi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nGiống như nhiều người khác, tôi đã dành cả tuổi thơ để chờ đợi lá thư từ Hogwarts. Tôi đã đọc sách, xem phim và chơi tất cả các trò chơi video có sự chuyển thể từ Harry Potter hứa hẹn mang lại một phần của thế giới phù thủy. Một số thì thú vị, hầu hết thì dễ quên, nhưng không có trò nào thực sự mang lại trải nghiệm mà tôi đã hình dung – ước mơ được là một học sinh tại Hogwarts.\r\n11/03/2025 11:36 PC/Console\r\nKhi Hogwarts Legacy được công bố, tôi muốn hào hứng. Nhưng tôi đã từng thất vọng trước đó. Liệu đây có thực sự là trò chơi Harry Potter mà chúng ta luôn mong đợi? Liệu nó có thể tái hiện được phép thuật của Hogwarts, hay chỉ là một trò chơi thế giới mở vô hồn với lớp vỏ phù thủy bên ngoài?\r\n\r\n\r\n\r\nSau đó, tôi bước vào lâu đài lần đầu tiên. Đại sảnh lấp lánh ánh nến. Những hồn ma trôi qua các hành lang. Một bộ giáp kêu lạch cạch khi tôi đi ngang qua. Và lần đầu tiên, Hogwarts thật sự sống động. Đó là lúc tôi biết rằng đây là điều gì đó khác biệt. Bạn có thể mua Hogwarts Legacy với mức giá rẻ nhất trên PlayStation 5.\r\n\r\nSau khi dành hàng chục giờ để khám phá mọi ngóc ngách của Hogwarts Legacy, tôi có thể tự tin nói rằng trò chơi này mang lại ước mơ về một cuộc phiêu lưu trong thế giới phù thủy hoàn chỉnh. Dưới đây là những điểm sáng của trò chơi này.\r\n\r\nTrải nghiệm Hogwarts sống động nhất từng có\r\nNgôi sao thực sự của trò chơi này chính là Hogwarts. Avalanche Software đã tạo ra một phiên bản lâu đài tràn đầy sức sống, bí ẩn và đầy ắp những bí mật. Khi đi qua những hành lang lát đá, bạn sẽ bắt gặp hồn ma trôi lơ lửng, những bộ giáp di chuyển và học sinh chơi khăm nhau bằng phép thuật. Sự chú ý đến từng chi tiết thực sự đáng kinh ngạc.\r\n\r\nHogwarts là một mê cung của các căn phòng ẩn, cánh cửa bí mật và những cầu thang xoắn ốc. Dù dành hàng giờ để khám phá, bạn vẫn luôn có thể tìm thấy một khu vực mới chưa từng thấy trước đó. Mỗi nơi trong lâu đài đều có phong cách riêng—phòng sinh hoạt chung của Gryffindor ấm cúng với nét cổ kính, Ravenclaw mang đậm màu sắc thiên văn, Hufflepuff thì ấm cúng và ẩn sâu dưới lòng đất, còn Slytherin lại toát lên vẻ âm u đầy bí ẩn.\r\n\r\n\r\nKhông chỉ lâu đài, mà cả môi trường xung quanh cũng thay đổi theo mùa. Vào mùa thu, bạn sẽ thấy những quả bí ngô trang trí khắp nơi, còn mùa đông thì toàn bộ khuôn viên phủ đầy tuyết trắng. Rừng Cấm thì luôn u ám và đầy rẫy những sinh vật nguy hiểm. Tôi tin rằng có hàng triệu fan Harry Potter sẵn sàng dành hàng giờ chỉ để khám phá Hogwarts trong game này.\r\n\r\nBan đầu, tôi khá nghi ngờ về hệ thống chiến đấu bằng phép thuật, nhưng Hogwarts Legacy thực sự đã làm tốt điều này. Trò chơi mang đến một hệ thống chiến đấu thú vị, đòi hỏi chiến thuật và vô cùng mãn nhãn.\r\n\r\nĐiểm thú vị nhất là khả năng kết hợp các câu thần chú với nhau. Bạn có thể kéo kẻ địch về phía mình bằng Accio, thiêu đốt chúng bằng Incendio, rồi kết liễu bằng Bombarda. Kẻ thù có các lớp khiên màu sắc khác nhau, và bạn cần sử dụng phép thuật phù hợp để phá vỡ chúng. Cơ chế đỡ đòn và né tránh hoạt động khá mượt mà, và càng thuần thục thì bạn càng có thể chiến đấu hiệu quả hơn.\r\n\r\nNgoài ra, khi chiến đấu, bạn sẽ tích lũy năng lượng để tung ra những đòn phép thuật cực mạnh với hiệu ứng hoành tráng. Khi thăng cấp, bạn có thể mở khóa các kỹ năng nâng cao cho phép thuật của mình, giúp tạo ra những chuỗi combo độc đáo và mạnh mẽ hơn.\r\nBên ngoài Hogwarts, Hogwarts Legacy mang đến một thế giới mở rộng lớn với vô số hoạt động, địa điểm khám phá và bí ẩn chờ đợi người chơi. Cảm giác cưỡi chổi bay qua những vùng đất rộng lớn thực sự khiến việc khám phá trở nên thú vị.\r\nCó hơn 100 nhiệm vụ phụ trong game, và nhiều trong số đó có cốt truyện riêng cùng các nhân vật đáng nhớ. Một số nhiệm vụ đơn giản chỉ là đi tìm đồ vật, nhưng nhiều nhiệm vụ khác lại có chiều sâu, kèm theo những lựa chọn đạo đức có thể ảnh hưởng đến diễn biến câu chuyện.\r\n\r\nMột điểm tôi rất thích là Phòng Yêu Cầu (Room of Requirement), nơi bạn có thể tùy chỉnh theo sở thích, trồng cây, chế thuốc, và thậm chí chăm sóc sinh vật huyền bí như Niffler, Hippogriff hay Mooncalf.\r\n\r\nNgoài ra, nếu bạn muốn đi theo con đường Hắc Ám, bạn hoàn toàn có thể học và sử dụng các Lời Nguyền Không Thể Tha Thứ, bao gồm Avada Kedavra. Tuy nhiên, điều này sẽ dẫn đến những phản ứng và hậu quả khác nhau từ NPC và thế giới trong game.\r\nCó rất nhiều điều để yêu thích về Hogwarts Legacy, nhưng một trong những điểm tôi trân trọng nhất là trải nghiệm chơi game không bị ảnh hưởng bởi hình thức kiếm tiền phiền phức. Bạn chỉ cần mua một lần và có thể trải nghiệm toàn bộ trò chơi mà không cần lo lắng về giao dịch vi mô hay nội dung bị khóa sau tường phí. Đây là một tựa game single-player thuần túy, mang lại trải nghiệm Harry Potter tốt nhất cho các fan.\r\n\r\nNếu bạn là một Potterhead, tôi không có lý do gì để không khuyên bạn nên thử Hogwarts Legacy!', 'img/tin_tuc/anh8.png', '\r\nMọt Hóng', '2025-03-11 03:53:31');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `order_detail`
--

CREATE TABLE `order_detail` (
  `order_id` varchar(19) NOT NULL,
  `game_id` varchar(8) NOT NULL,
  `price_at_add` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `order_detail`
--

INSERT INTO `order_detail` (`order_id`, `game_id`, `price_at_add`) VALUES
('order20250323155852', 'G10', 275400),
('order20250323155920', 'G3', 499000),
('order20250323160016', 'G1', 249500),
('order20250323160016', 'G12', 74500),
('order20250323160016', 'G15', 99000),
('order20250323160200', 'G1', 249500),
('order20250323160200', 'G15', 99000);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `publishers`
--

CREATE TABLE `publishers` (
  `publisher_id` varchar(5) NOT NULL,
  `publisher_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `publishers`
--

INSERT INTO `publishers` (`publisher_id`, `publisher_name`) VALUES
('P1', 'Rockstar Games'),
('P10', '2K Games'),
('P11', 'Valve'),
('P12', 'Chess.com'),
('P13', 'Capcom'),
('P14', 'Team Cherry'),
('P15', 'ConcernedApe Chucklefish'),
('P2', 'CD Projekt Red'),
('P3', 'Xbox Game Studios'),
('P4', 'Nintendo'),
('P5', 'Electronic Arts'),
('P6', 'Activision'),
('P7', 'Beat Games'),
('P8', 'EA Sports'),
('P9', 'Fishing Planet LLC');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `purchase_order`
--

CREATE TABLE `purchase_order` (
  `order_id` varchar(19) NOT NULL,
  `user_id` varchar(10) NOT NULL,
  `purchase_date` date NOT NULL,
  `status` enum('Chờ xử lý','Hoàn tất','Đã hủy','Hoàn tiền') NOT NULL,
  `total_price` float NOT NULL,
  `pay_method` enum('Paypal','ATM nội địa') NOT NULL DEFAULT 'Paypal'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `purchase_order`
--

INSERT INTO `purchase_order` (`order_id`, `user_id`, `purchase_date`, `status`, `total_price`, `pay_method`) VALUES
('order20250323155852', 'u4', '2025-03-23', 'Hoàn tất', 275400, 'Paypal'),
('order20250323155920', 'u4', '2025-03-23', 'Hoàn tất', 499000, 'Paypal'),
('order20250323160016', 'u4', '2025-03-23', 'Hoàn tất', 423000, 'Paypal'),
('order20250323160200', 'u5', '2025-03-23', 'Hoàn tất', 348500, 'Paypal');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `reviews`
--

CREATE TABLE `reviews` (
  `reviews_id` varchar(5) NOT NULL,
  `user_id` varchar(10) NOT NULL,
  `game_id` varchar(8) NOT NULL,
  `rating` float NOT NULL,
  `comment` varchar(1000) NOT NULL,
  `review_date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `reviews`
--

INSERT INTO `reviews` (`reviews_id`, `user_id`, `game_id`, `rating`, `comment`, `review_date`) VALUES
('rv1', 'u5', 'G15', 5, 'Game quá hay', '2025-03-23 16:02:43');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `system_requirements`
--

CREATE TABLE `system_requirements` (
  `game_id` varchar(8) NOT NULL,
  `min_os` varchar(255) NOT NULL,
  `min_cpu` varchar(255) NOT NULL,
  `min_ram` varchar(50) NOT NULL,
  `min_gpu` varchar(255) NOT NULL,
  `min_storage` varchar(50) NOT NULL,
  `rec_os` varchar(255) DEFAULT NULL,
  `rec_cpu` varchar(255) DEFAULT NULL,
  `rec_ram` varchar(50) DEFAULT NULL,
  `rec_gpu` varchar(255) DEFAULT NULL,
  `rec_storage` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `system_requirements`
--

INSERT INTO `system_requirements` (`game_id`, `min_os`, `min_cpu`, `min_ram`, `min_gpu`, `min_storage`, `rec_os`, `rec_cpu`, `rec_ram`, `rec_gpu`, `rec_storage`) VALUES
('G1', 'Windows 7 64-bit', 'Intel Core 2 Quad Q6600 / AMD Phenom 9850', '4GB', 'NVIDIA 9800 GT / AMD HD 4870', '65GB', 'Windows 10 64-bit', 'Intel Core i5 3470 / AMD FX-8350', '8GB', 'NVIDIA GTX 660 / AMD HD 7870', '65GB'),
('G10', 'Windows 7 64-bit', 'Intel Core 2 Duo E4700 / AMD Phenom 9950', '4GB', 'NVIDIA GTX 460 / AMD HD 5770', '45GB', 'Windows 10 64-bit', 'Intel Core i5-2390T / AMD FX-4300', '8GB', 'NVIDIA GTX 770 / AMD R9 290', '45GB'),
('G11', 'Windows 7 32-bit', 'Intel Core 2 Duo / AMD Athlon 64 X2', '2GB', 'NVIDIA 7600 / ATI X800', '8GB', 'Windows 10 64-bit', 'Intel Core i5 750 / AMD Phenom II X4', '4GB', 'NVIDIA GTX 650 / AMD HD 7750', '8GB'),
('G12', 'Windows 7 64-bit', 'Intel Core 2 Duo E6600', '2GB', 'Intel HD 3000', '3GB', 'Windows 10 64-bit', 'Intel Core i3 2.5GHz', '4GB', 'NVIDIA GTX 750', '3GB'),
('G13', 'Windows 10 64-bit', 'Intel Core i5-6600K / AMD Ryzen 5 1600', '8GB', 'NVIDIA GTX 1060 / AMD RX 580', '100GB', 'Windows 11 64-bit', 'Intel Core i7-8700K / AMD Ryzen 7 2700X', '16GB', 'NVIDIA RTX 2060 / AMD RX 5700 XT', '100GB'),
('G14', 'Windows 7 64-bit', 'Intel Core 2 Quad Q9650 / AMD Phenom II X4 965', '4GB', 'NVIDIA GTX 750 Ti / AMD HD 7850', '20GB', 'Windows 10 64-bit', 'Intel Core i5-3470 / AMD FX-8350', '8GB', 'NVIDIA GTX 970 / AMD R9 390', '20GB'),
('G15', 'Windows 10 64-bit', 'Intel Core i3-7100 / AMD Ryzen 3 1200', '6GB', 'NVIDIA GTX 950 / AMD R7 370', '40GB', 'Windows 11 64-bit', 'Intel Core i5-8600 / AMD Ryzen 5 2600', '12GB', 'NVIDIA GTX 1660 / AMD RX 5600 XT', '40GB'),
('G2', 'Windows 7 64-bit', 'Intel Core i5-2500K / AMD Phenom II X4 940', '6GB', 'NVIDIA GTX 660 / AMD HD 7870', '35GB', 'Windows 10 64-bit', 'Intel Core i7 3770 / AMD FX-8350', '8GB', 'NVIDIA GTX 770 / AMD R9 290', '50GB'),
('G3', 'Windows 10 64-bit', 'Intel Core i5-6300U', '8GB', 'Intel HD 520', '50GB', 'Windows 10 64-bit', 'Intel Core i5-4460 / AMD Ryzen 5 1600', '16GB', 'NVIDIA GTX 970 / AMD RX 570', '50GB'),
('G4', 'Nintendo Switch', 'Tegra X1', '4GB', 'Integrated', '14GB', 'Nintendo Switch', 'Tegra X1', '4GB', 'Integrated', '14GB'),
('G5', 'Windows XP', 'Intel Core 2 Duo 2.0 GHz', '2GB', 'Intel GMA 4500 / NVIDIA 7800', '12GB', 'Windows 7', 'Intel Core i5 2.5GHz', '4GB', 'NVIDIA GTX 560', '12GB'),
('G6', 'Windows 10 64-bit', 'Intel Core i3-4340 / AMD FX-6300', '8GB', 'NVIDIA GTX 670 / AMD HD 7950', '175GB', 'Windows 10 64-bit', 'Intel Core i5-2500K / AMD Ryzen 5 1600X', '12GB', 'NVIDIA GTX 970 / AMD RX 580', '175GB'),
('G7', 'Windows 7 64-bit', 'Intel Core i5 Sandy Bridge', '4GB', 'NVIDIA GTX 960 / AMD R9 280', '2GB', 'Windows 10 64-bit', 'Intel Core i7 Skylake', '8GB', 'NVIDIA GTX 1060 / AMD RX 480', '2GB'),
('G8', 'Windows 10 64-bit', 'Intel Core i3-6100 / AMD Athlon X4 880K', '8GB', 'NVIDIA GTX 660 / AMD HD 7850', '50GB', 'Windows 10 64-bit', 'Intel Core i5-3550 / AMD FX-8150', '12GB', 'NVIDIA GTX 1050 Ti / AMD RX 570', '50GB'),
('G9', 'Windows 7 64-bit', 'Intel Core 2 Duo 3.0 GHz', '4GB', 'NVIDIA GTX 460', '12GB', 'Windows 10 64-bit', 'Intel Core i5-6400', '8GB', 'NVIDIA GTX 970 / AMD RX 570', '12GB');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `type_categories`
--

CREATE TABLE `type_categories` (
  `type_id` varchar(5) NOT NULL,
  `type_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `type_categories`
--

INSERT INTO `type_categories` (`type_id`, `type_name`) VALUES
('T1', 'Thể loại'),
('T2', 'Chủ đề'),
('T3', 'Mục đặc biệt'),
('T4', 'Hỗ trợ');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user`
--

CREATE TABLE `user` (
  `user_Id` varchar(10) NOT NULL,
  `user_Name` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `created_at` date NOT NULL,
  `role` enum('admin','user') NOT NULL DEFAULT 'user'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `user`
--

INSERT INTO `user` (`user_Id`, `user_Name`, `email`, `Password`, `created_at`, `role`) VALUES
('u1', 'TH', 'tranhien123@gmail.com', '123', '2025-03-01', 'admin'),
('u2', 'Nguyễn Lưu Nguyễn', 'nguyenluunguyen123@gmail.com', '123', '2020-03-05', 'user'),
('u3', 'Võ Tuấn Khang', 'votuankhang123@gmail.com', '123', '2020-03-11', 'user'),
('u4', 'u2', 'hien@gmail.deptrai', '123', '2025-03-14', 'user'),
('u5', 'fmda', 'nguyenluunguyen1234@gmail.com', 'ads', '2025-03-14', 'user'),
('u6', 'LoveLy', 'anhduong12334324lffsf@g.bruh', '123', '2025-03-14', 'admin');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user_library`
--

CREATE TABLE `user_library` (
  `userlibrary_id` varchar(5) NOT NULL,
  `user_id` varchar(10) NOT NULL,
  `game_id` varchar(8) NOT NULL,
  `purchase_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `user_library`
--

INSERT INTO `user_library` (`userlibrary_id`, `user_id`, `game_id`, `purchase_date`) VALUES
('lib1', 'u4', 'G10', '2025-03-23'),
('lib2', 'u4', 'G3', '2025-03-23'),
('lib3', 'u4', 'G1', '2025-03-23'),
('lib4', 'u4', 'G12', '2025-03-23'),
('lib5', 'u4', 'G15', '2025-03-23'),
('lib6', 'u5', 'G1', '2025-03-23'),
('lib7', 'u5', 'G15', '2025-03-23');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cart_id`),
  ADD KEY `fk_cart_game` (`game_id`),
  ADD KEY `fk_cart_user` (`user_id`);

--
-- Chỉ mục cho bảng `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`categories_id`),
  ADD KEY `fk_categories_type` (`type_id`);

--
-- Chỉ mục cho bảng `categories_game`
--
ALTER TABLE `categories_game`
  ADD KEY `fk_categame_game` (`gameID`),
  ADD KEY `fk_categame_categories` (`categoriesID`);

--
-- Chỉ mục cho bảng `developers`
--
ALTER TABLE `developers`
  ADD PRIMARY KEY (`developers_id`);

--
-- Chỉ mục cho bảng `discounts`
--
ALTER TABLE `discounts`
  ADD PRIMARY KEY (`discount_id`);

--
-- Chỉ mục cho bảng `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`game_id`),
  ADD KEY `fk_game_public` (`publisherID`);

--
-- Chỉ mục cho bảng `game_developers`
--
ALTER TABLE `game_developers`
  ADD KEY `fk_gamedev_game` (`game_id`),
  ADD KEY `fk_gamedev_developers` (`developers_id`);

--
-- Chỉ mục cho bảng `game_discounts`
--
ALTER TABLE `game_discounts`
  ADD KEY `fk_gamedis_game` (`game_id`),
  ADD KEY `fk_gamedis_discount` (`discount_id`);

--
-- Chỉ mục cho bảng `game_img`
--
ALTER TABLE `game_img`
  ADD PRIMARY KEY (`img_id`),
  ADD KEY `fk_game_img` (`game_id`);

--
-- Chỉ mục cho bảng `game_price`
--
ALTER TABLE `game_price`
  ADD PRIMARY KEY (`price_id`),
  ADD KEY `fk_price_game` (`game_id`);

--
-- Chỉ mục cho bảng `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`news_id`);

--
-- Chỉ mục cho bảng `order_detail`
--
ALTER TABLE `order_detail`
  ADD PRIMARY KEY (`order_id`,`game_id`),
  ADD KEY `game_id` (`game_id`);

--
-- Chỉ mục cho bảng `publishers`
--
ALTER TABLE `publishers`
  ADD PRIMARY KEY (`publisher_id`);

--
-- Chỉ mục cho bảng `purchase_order`
--
ALTER TABLE `purchase_order`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_order_user` (`user_id`);

--
-- Chỉ mục cho bảng `reviews`
--
ALTER TABLE `reviews`
  ADD PRIMARY KEY (`reviews_id`),
  ADD KEY `fk_review_user` (`user_id`),
  ADD KEY `fk_review` (`game_id`);

--
-- Chỉ mục cho bảng `system_requirements`
--
ALTER TABLE `system_requirements`
  ADD PRIMARY KEY (`game_id`);

--
-- Chỉ mục cho bảng `type_categories`
--
ALTER TABLE `type_categories`
  ADD PRIMARY KEY (`type_id`);

--
-- Chỉ mục cho bảng `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_Id`);

--
-- Chỉ mục cho bảng `user_library`
--
ALTER TABLE `user_library`
  ADD PRIMARY KEY (`userlibrary_id`),
  ADD KEY `fk_library_user` (`user_id`),
  ADD KEY `fk_library_game` (`game_id`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `fk_cart_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`),
  ADD CONSTRAINT `fk_cart_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_Id`);

--
-- Các ràng buộc cho bảng `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `fk_categories_type` FOREIGN KEY (`type_id`) REFERENCES `type_categories` (`type_id`);

--
-- Các ràng buộc cho bảng `categories_game`
--
ALTER TABLE `categories_game`
  ADD CONSTRAINT `fk_categame_categories` FOREIGN KEY (`categoriesID`) REFERENCES `categories` (`categories_id`),
  ADD CONSTRAINT `fk_categame_game` FOREIGN KEY (`gameID`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `fk_game_public` FOREIGN KEY (`publisherID`) REFERENCES `publishers` (`publisher_id`);

--
-- Các ràng buộc cho bảng `game_developers`
--
ALTER TABLE `game_developers`
  ADD CONSTRAINT `fk_gamedev_developers` FOREIGN KEY (`developers_id`) REFERENCES `developers` (`developers_id`),
  ADD CONSTRAINT `fk_gamedev_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `game_discounts`
--
ALTER TABLE `game_discounts`
  ADD CONSTRAINT `fk_gamedis_discount` FOREIGN KEY (`discount_id`) REFERENCES `discounts` (`discount_id`),
  ADD CONSTRAINT `fk_gamedis_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `game_img`
--
ALTER TABLE `game_img`
  ADD CONSTRAINT `fk_game_img` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `game_price`
--
ALTER TABLE `game_price`
  ADD CONSTRAINT `fk_price_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `order_detail`
--
ALTER TABLE `order_detail`
  ADD CONSTRAINT `order_detail_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `purchase_order` (`order_id`),
  ADD CONSTRAINT `order_detail_ibfk_2` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`);

--
-- Các ràng buộc cho bảng `purchase_order`
--
ALTER TABLE `purchase_order`
  ADD CONSTRAINT `fk_order_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_Id`);

--
-- Các ràng buộc cho bảng `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `fk_review` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`),
  ADD CONSTRAINT `fk_review_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_Id`);

--
-- Các ràng buộc cho bảng `system_requirements`
--
ALTER TABLE `system_requirements`
  ADD CONSTRAINT `system_requirements_ibfk_1` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `user_library`
--
ALTER TABLE `user_library`
  ADD CONSTRAINT `fk_library_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`game_id`),
  ADD CONSTRAINT `fk_library_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
