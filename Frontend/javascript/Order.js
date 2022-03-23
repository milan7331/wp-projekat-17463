import { PCPart } from "./PCPart.js";
import { PCStore } from "./PCStore.js";

export class Order{
    constructor(id, quantity, price){
        this.id = id;
        this.quantity = quantity;
        this.price = price;
        this.part = null;
        this.store = null;
    }
    addPartAndStore(part, store){
        this.part = part;
        this.store = store;
    }
    draw(host){
        let tableBody = host;

        let row = document.createElement("tr");
        tableBody.appendChild(row);

        //-------------------------------------------

        let field = document.createElement("td");
        row.appendChild(field);

        let div = document.createElement("div");
        div.classList.add("pictureDIV");
        field.appendChild(div);

        let picture = document.createElement("img");
        picture.src = "./images/products/"+this.part.serialNumber+".png";
        picture.classList.add("productPicture");
        div.appendChild(picture);

        field = document.createElement("label");
        field.innerHTML = this.part.productName;
        div.appendChild(field);

        //---------------------------------------------

        field = document.createElement("td");
        row.appendChild(field);

        div = document.createElement("div");
        div.classList.add("purchaseLocationDIV");
        field.appendChild(div);

        field = document.createElement("label");
        field.innerHTML = this.store.name;
        div.appendChild(field);

        field = document.createElement("label");
        field.innerHTML = this.store.storeLocation;
        div.appendChild(field);

        //----------------------------------------------

        field = document.createElement("td");
        field.innerHTML = this.quantity;
        row.appendChild(field);

        //----------------------------------------------

        field = document.createElement("td");
        field.innerHTML = this.price;
        row.appendChild(field);
    }
}