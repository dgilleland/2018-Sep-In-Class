<Query Kind="Expression">
  <Connection>
    <ID>2f871659-b227-4d65-a411-ef19b1c695a8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// The retaurant Host (who is in charge of the waiters, 
// seats people and takes payments) needs the following information:
// Waiters with active customers (bills not paid)

// Here's an answer where we start with the Bills
//from customerBill in Bills
//where customerBill.PaidStatus == false
//select customerBill.Waiter

from employee in Waiters
from customerBill in employee.Bills
where customerBill.PaidStatus == false
select employee




