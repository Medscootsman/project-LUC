BULK INSERT Table4
    FROM 'C:\Users\User\Documents\data.csv'
   WITH   
      (  
         FIELDTERMINATOR =',',  
         ROWTERMINATOR ='\n'  
      );  