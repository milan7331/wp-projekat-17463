import { WebStore } from "./WebStore.js";
export class UserAccount{
    constructor(id, firstn, lastn, city, address, postal, phone, mail){
        this.id = id;
        this.firstName = firstn;
        this.lastName = lastn;
        this.city = city;
        this.address = address;
        this.postalCode = postal;
        this.phoneNumber = phone;
        this.mailAddress = mail;
        this.orders = [];
    }
    drawTable(host){
        let tableBody = host;

        let row = document.createElement("tr");
        tableBody.appendChild(row);

        let field = document.createElement("td");
        field.innerHTML = this.firstName;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.lastName;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.city;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.address;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.postalCode;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.phoneNumber;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.mailAddress;
        row.appendChild(field);
    }
    addOrder(order){
        this.orders.push(order);
    }

}