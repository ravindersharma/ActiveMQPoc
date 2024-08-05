To setup and run the ActiveMQ Poc porject you need to perform following steps:
  1. Instal ActiveMQ Latest Version on Windows machince from  here: https://activemq.apache.org/components/classic/download/
  2. When you install it (means setup it  C drive with ActiveMQ folder you have to start it )
  3. Start ActiveMq with command : activemq start    
      if you face issue for java run time the download it from : https://www.java.com/en/download/manual.jsp   , then setup JAVA_Home Environment variable for java installation path. step are here :https://confluence.atlassian.com/doc/setting-the-java_home-variable-in-windows-8895.html
  
      After Java Setup try to run again the ActiveMQ once it up  and running. you can see it Admin dashboard at url : http://127.0.0.1:8161/

 4. now you have to click on queues and create a new queue to test POC. Once you create a queue As I have setup for this test : testQueue   . you can choose whatever name for your Queue but make sure same will be update in Application. Since its POC and I have hard coded it in solution.

 5. then you have to run the both application ( producer and Consumer ) together and the send message which is predefined in producer and same will be visible in ActiveMQ dashboard under your queue and same will be received in consumer.
