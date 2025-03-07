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