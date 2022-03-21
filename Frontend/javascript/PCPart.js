export class PCPart{
    constructor(id, sn, pname, pcat, price){
        this.id = id;
        this.serialNumber = sn;
        this.productName = pname;
        this.productCategory = pcat;
        this.price = price;
    }

    draw(host){
        let tableBody = host;

        let row = document.createElement("tr");
        tableBody.appendChild(row);

        let field = document.createElement("td");
        let radio = document.createElement("input");
        radio.classList.add("productRadio");
        radio.type = "radio";
        radio.value = this.id;
        radio.name = "proizvodi";
        field.appendChild(radio);
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.serialNumber;
        row.appendChild(field);

 
        field = document.createElement("td");

        let picField = document.createElement("div");
        picField.classList.add("pictureDIV");


        let picture = document.createElement("img");
        picture.src = "./images/products/"+this.serialNumber+".png";
        picture.classList.add("productPicture");
        picField.appendChild(picture);

        let text = document.createElement("label");
        text.innerHTML = this.productName;
        text.classList.add("productName");
        picField.appendChild(text);

        field.appendChild(picField);
        row.appendChild(field);
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.productCategory;
        row.appendChild(field);

        field = document.createElement("td");
        field.innerHTML = this.price;
        row.appendChild(field);
    }
}