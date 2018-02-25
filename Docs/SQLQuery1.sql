SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NULL,
	[FieldSpecialist] [nvarchar](300)  NULL,
	[OfficeLocation] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IPK_Doctor] ON [dbo].[Doctor] 
(
	[DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT [dbo].[Doctor] ([DoctorId], [Name], [FieldSpecialist], [OfficeLocation]) VALUES (1, N'Joe', N'Medical Oncologist', N'A02')
INSERT [dbo].[Doctor] ([DoctorId], [Name], [FieldSpecialist], [OfficeLocation]) VALUES (2, N'Chad', N'Respiratory Therapist', N'B20')
INSERT [dbo].[Doctor] ([DoctorId], [Name], [FieldSpecialist], [OfficeLocation]) VALUES (3, N'Tiffany', N'TB Case Manager', N'B28')
SET IDENTITY_INSERT [dbo].[Doctor] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[Name] [nvarchar](120) NULL,
	[Age] [int]  NULL,
	[Disease] [nvarchar](300) NULL,
 CONSTRAINT [PK__Patient_97B4BE370AD2A005] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IFK_Doctor_Patient] ON [dbo].[Patient] 
(
	[DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IPK_Patient] ON [dbo].[Patient] 
(
	[PatientId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET IDENTITY_INSERT [dbo].[Patient] ON
INSERT [dbo].[Patient] ([PatientId], [DoctorId], [Name], [Age], [Disease]) VALUES (1, 1, N'Alex', 60, N'Cancer')
INSERT [dbo].[Patient] ([PatientId], [DoctorId], [Name], [Age], [Disease]) VALUES (2, 1, N'Sanju', 35,  N'Cancer')
INSERT [dbo].[Patient] ([PatientId], [DoctorId], [Name], [Age], [Disease]) VALUES (3, 2, N'Tony', 55, N'Asthma')
INSERT [dbo].[Patient] ([PatientId], [DoctorId], [Name], [Age], [Disease]) VALUES (4, 3, N'Joshua', 65,  N'TB')
INSERT [dbo].[Patient] ([PatientId], [DoctorId], [Name], [Age], [Disease]) VALUES (5, 3, N'Rammy', 62,  N'TB')
SET IDENTITY_INSERT [dbo].[Patient] OFF

ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK__Patient__Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([DoctorId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK__Patient__DoctorId]
GO