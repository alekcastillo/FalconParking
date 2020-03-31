--Parking lot

CREATE TABLE ParkingLotView (
	aggregate_id int primary key
	,code varchar(10) 
	,total_slots_count int 
	,available_slots_count int
	,lot_status int
	--Base View Columns
	,created_time Date
	,created_by varchar(20)
	,update_time Date
	,updated_by varchar(20)
	,deleted_time Date
	,deleted_by varchar(20)
)

CREATE TABLE ParkingLotEventLog (
	id guid
	,parking_lot_id int
	,event_type_id int
	,event_data json
	--Base EventLog Columns
	,created_time Date
	,created_by varchar(20)
)

CREATE TABLE ParkingLotEventType (
	event_type_id int
	,event_type varchar(20)
)

CREATE TABLE ParkingLotStatus (
	status_id int
	,status varchar(20)
)

--ParkingSlot

 CREATE TABLE ParkingSlotView (
	aggregate_id int
	,slot_id int
	,slot_status int
	--Base View Columns
	--,created_time Date
	--,created_by varchar(20)
	,update_time Date
	,updated_by varchar(20)
	--,deleted_time Date
	--,deleted_by varchar(20)
)

--User

CREATE TABLE user_view (
	Date updated_time,
	varchar(20) updated_by,
	Date deleted_time,
	varchar(20) deleted_by,
) inherits (base_model)

CREATE TABLE user_eventlog (
	int id,
	varchar(15) title,
	varchar(100) description
) inherits (base_model)

--User

CREATE TABLE vehicle_view (
	Date updated_time,
	varchar(20) updated_by,
	Date deleted_time,
	varchar(20) deleted_by,
) inherits (base_model)

CREATE TABLE vehicle_eventlog (
	int id,
	varchar(15) title,
	varchar(100) description
) inherits (base_model)
