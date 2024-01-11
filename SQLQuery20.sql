SELECT Distinct HQName, Country AS HQCountry, OfficeName, OfficeTown, dbo.Computers.Type AS ComputerType, dbo.Computers.Brand AS ComputerBrand, dbo.Computers.Model AS ComputerModel
FROM dbo.Computers, dbo.HQs, dbo.Offices, dbo.Phones
WHERE dbo.HQs.Id = dbo.Offices.HQId AND dbo.Offices.Id = dbo.Computers.Id