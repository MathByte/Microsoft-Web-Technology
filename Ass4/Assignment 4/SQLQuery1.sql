select * from general_ledger_accounts
select * from invoice_line_items


select * from general_ledger_accounts
inner join invoice_line_items
on general_ledger_accounts.account_number = invoice_line_items.account_number
where general_ledger_accounts.account_number = 150



select * from invoice_line_items
inner join invoices
on invoice_line_items.invoice_id = invoices.invoice_id

where invoices.vendor_id = 110

select * from invoices
where vendor_id = 110

select * from invoice_line_items

select * from invoices

select * from vendors

update vendors
set
is_deleted = 0
where
vendor_id is not null

select  i.vendor_id, i.invoice_id, s.line_item_description from invoice_line_items s
inner join invoices i on s.invoice_id = i.invoice_id
where i.vendor_id = 110