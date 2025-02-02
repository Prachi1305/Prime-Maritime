﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class PARTY_MASTER
    {
        public int CUST_ID { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CUST_EMAIL { get; set; }
        public string CUST_CONTACT { get; set; }
        public string CUST_TYPE { get; set; }
        public string GSTIN { get; set; }
        public string VAT_NO { get; set; }
        public Boolean STATUS { get; set; }
        public string REMARKS { get; set; }
        public string AGENT_CODE { get; set; }
        public string CREATED_BY { get; set; }
    }

    public class CONTAINER_MASTER
    {
        public int ID { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public DateTime ONHIRE_DATE { get; set; }      
        public string ONHIRE_LOCATION { get; set; }      
        public string LEASED_FROM { get; set; }      
        public bool STATUS { get; set; }
    }

    public class MASTER
    {
        public int ID { get; set; }

        public string KEY_NAME { get; set; }

        public string CODE { get; set; }

        public string CODE_DESC { get; set; }

        public Boolean STATUS { get; set; }

        public string PARENT_CODE { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; } = null;

        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_DATE { get; set; } = null;

    }

    public class VESSEL_MASTER
    {
        public int ID { get; set; }

        public string VESSEL_NAME { get; set; }

        public string IMO_NO { get; set; }

        public string COUNTRY_CODE { get; set; }

        public string VESSEL_CODE { get; set; }

        public Boolean STATUS { get; set; }

        public string CREATED_BY { get; set; }

        //public DateTime CREATED_ON { get; set; }

        //public string UPDATED_BY { get; set; }

        //public DateTime UPDATED_DATE { get; set; }
    }

    public class SERVICE_MASTER
    {
        public int ID { get; set; }

        public string LINER_CODE { get; set; }

        public string SERVICE_NAME { get; set; }

        public string PORT_CODE { get; set; }

        public Boolean STATUS { get; set; }

        public string CREATED_BY { get; set; }
    }

    public class CONTAINER_TYPE
    {
        public int ID { get; set; }

        public string CONT_TYPE_CODE { get; set; }

        public string CONT_TYPE { get; set; }

        public int CONT_SIZE { get; set; }

        public string ISO_CODE { get; set; }

        public int TEUS { get; set; }

        public string OUT_DIM { get; set; }

        public Boolean STATUS { get; set; }


        public string CREATED_BY { get; set; }
    }

    public class ICD_MASTER
    {
        public int ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_TYPE { get; set; }
        public string ADDRESS { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string ASSOCIATE_PORT_CODE { get; set; }
        public bool LOC_TYPE_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }

    }

    public class DEPO_MASTER
    {
        public int ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_TYPE { get; set; }
        public string ADDRESS { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string ASSOCIATE_PORT_CODE { get; set; }
        public string LOC_TYPE_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }

    }

    public class TERMINAL_MASTER
    {
        public int ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_TYPE { get; set; }
        public string ADDRESS { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string ASSOCIATE_PORT_CODE { get; set; }
        public bool LOC_TYPE_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }

    }

    public class LINER
    {
        public int ID { get; set; }

        public string NAME { get; set; }

        public string CODE { get; set; }

        public string DESCRIPTION { get; set; }

        public Boolean STATUS { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_DATE { get; set; }
    }

    public class SERVICE
    {
        public int ID { get; set; }

        public String LINER_CODE { get; set; }

        public String SERVICE_NAME { get; set; }

        public String PORT_CODE { get; set; }

        public Boolean STATUS { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_DATE { get; set; }


    }

    public class SCHEDULE
    {
        public int ID { get; set; }

        public string VESSEL_NAME { get; set; }

        public string SERVICE_NAME { get; set; }

        public string PORT_CODE { get; set; }

        public string VIA_NO { get; set; }

        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }

        public Boolean STATUS { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_DATE { get; set; }








    }

}
