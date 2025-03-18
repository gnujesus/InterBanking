# Onion

## Statements
- CRUD a user
- CRUD a transaction
- CRUD an account 
- CRUD a beneficiary 

## Entities
- User
- Transaction
- Account
- Beneficiary

### Relations
- User has many accounts
- Transaction belongs to a user from an account to another account 
- Transaction has types (Enum: deposit, payment)
- Account has many transactions
- User has types
- User has many beneficiaries

# Notes
- The connection string used in the appsettings.json may cause error, since I don't know if I should use postgre or postgresql on the connection string, or the port 5433 or 5432 (that depends on how it's set up)
