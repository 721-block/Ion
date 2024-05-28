insert into IonDb.dbo.Users (LastName, FirstName, Email, PhoneNumber, PathToPhoto, HashPassword) values
('������', '����', 'ivanivanov@mail.ru', '111', 'static/UserLogo.png', 'ee'),
('Brown', 'John', 'brownjohn@mail.ru', '222', 'static/UserLogo.png', 'vb'),
('Black', 'Jacob', 'blackjacob@mail.ru', '333', 'static/UserLogo.png', 'asd'),
('Smith', 'William', 'smithwilliam@mail.ru', '444', 'static/UserLogo.png', '1233');

insert into IonDb.dbo.Cars (UserId, GearboxType, Name, BodyType, IsAnnounced) values 
(1, 1, 'Kia rio', 1, 1),
(2, 1, 'Lada Granta', 1, 1),
(2, 1, 'Mersedes Benz', 1, 1);

insert into IonDb.dbo.Announcements (CarLocation, PricePerUnit, Description, AuthorId, CarId, AvailableDays, IsActive, PathToImages) values 
('{"X":15,"Y":37}', 5000, '������ ����� ����� ��� ���', 1, 1, 1, 1, 'wwwroot/images/defaultCarImages/'),
('{"X":40,"Y":70}', 7000, '������ ���� ������', 2, 2, 3, 1, 'wwwroot/images/defaultCarImages/'),
('{"X":80,"Y":90}', 15000, '������ ����� ���� ��� ������ ���������� �����', 2, 3, 1, 1, 'wwwroot/images/defaultCarImages/');

insert into IonDb.dbo.Bookings (AnnouncementId, ClientId, StartTime, EndTime) values
(1, 3, '2024-03-12', '2024-03-13'),
(2, 4, '2024-02-01', '2024-02-02'),
(3, 1, '2024-04-15', '2024-04-17');

insert into IonDb.dbo.TripRecords (UserId, AnnouncementId) values 
(3, 1),
(4, 2),
(1, 3)

insert into IonDb.dbo.Reviews (AnnouncementId, UserId, Content, Rating, CreationDate) values 
(1, 3, '������ �����', 5, '2024-03-15'),
(2, 4, '�������� �����, ������� ����������� ���������', 4.5, '2024-02-03'),
(3, 1, '���������� ����������', 4.3, '2024-04-17')