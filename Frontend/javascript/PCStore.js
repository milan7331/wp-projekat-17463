export class PCStore{
    constructor(id, name, phone, loc, mail){
        this.id = id;
        this.name = name;
        this.storePhoneNumber = phone;
        this.storeLocation = loc;
        this.storeMailAddress = mail;
    }

    draw(selectbox){
      let optionStore = document.createElement("option");
      optionStore.innerHTML = this.name + " - " + this.storeLocation ;
      optionStore.value = this.id;
      optionStore.classList.add("optionStore");
      selectbox.appendChild(optionStore);
    }
}
















/*
        "id": 1,
        "quantity": 2,
        "price": 1600,
        "part": {
          "id": 3,
          "serialNumber": 3,
          "productName": "NVIDIA RTX 3080",
          "productCategory": "Grafička kartica",
          "price": 800
        },
        "fromStore": {
          "id": 1,
          "name": "Prodajno mesto 1",
          "storePhoneNumber": 123456789,
          "storeLocation": "Centar",
          "storeMailAdress": "prod1@gmail.com"
        }
        */