declare @VehicleID int = 1

select * from ProjectPart pp
inner join Project p
	on pp.ProjectID = p.ProjectID
where pp.QuantityPurchased < pp.Quantity
and p.VehicleID = @VehicleID
and p.ProjectStatusID = 2