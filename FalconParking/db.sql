CREATE TABLE base_table (
	Date created_time,
	varchar(20) created_by,
)

CREATE TABLE base_model (
	Date updated_time,
	varchar(20) updated_by,
	Date deleted_time,
	varchar(20) deleted_by,
) inherits (base_model)

CREATE TABLE parking_event_type (
	int id,
	varchar(15) title,
	varchar(100) description
) inherits (base_model)

CREATE TABLE parking_lot (
	int id,
	varchar(10) title,
	int total_slots
) inherits (base_model)

CREATE TABLE parking_event (
	int parking_lot_id,
	int parking_event_type_id,
	json information
) inherits (base_table)