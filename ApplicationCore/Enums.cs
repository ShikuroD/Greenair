namespace ApplicationCore
{
    public enum STATUS
    {
        AVAILABLE,
        DISABLED,
        ORDERED,
        PAID,
        DEPARTED
    }
    public enum ORDER_ENUM
    {
        //general
        ID = 0,     //primary key
        NAME = 1,  //fullname in person
        STATUS = 2,

        //order
        DESCENDING = 3,
        ASCENDING = 4,

        //for person
        FIRST_NAME = 5,
        LAST_NAME = 6,
        BIRTHDATE = 7,
        PHONE = 8,
        ADDRESS = 9,

        //for customer
        EMAIL = 10,

        //for employee
        JOB_NAME = 11,
        SALARY = 12,

        //for account
        PERSON_NAME = 13,

        //for flight
        PLANE_NAME = 14,

        //for route
        ORIGIN_NAME = 15,
        DESTINATION_NAME = 16,

        //for ticket
        CUSTOMER_NAME = 17,

        //for tickettype
        BASEPRICE = 18

    }
}