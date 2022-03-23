import { Order } from "./Order.js";
import { PCPart } from "./PCPart.js"
import { PCStore } from "./PCStore.js";
import { UserAccount } from "./UserAccount.js"

export class WebStore{
    constructor(host){
        this.mainContainer = host;
        this.mainContainer.className = "mainContainer";
        this.mainNavbar = null;
        this.mainContent = null;
        this.footer = null;
        this.partsArray = [];
    }
    
    draw(){
        this.drawNavbar();
        this.drawContent();
        this.drawFooter();
    }

    drawNavbar(){
        this.mainNavbar = document.createElement("div");
        this.mainNavbar.className = "navbar";
        this.mainContainer.appendChild(this.mainNavbar);

        let title = document.createElement("label");
        title.classList.add("navbarTitle");
        title.innerHTML = "WebStore 17463";
        this.mainNavbar.appendChild(title);
        
        var buttons = document.createElement("div");
        buttons.classList.add("navbarButtons");
        this.mainNavbar.appendChild(buttons);
        
        let button = document.createElement("button");
        button.classList.add("buttonLight");
        button.innerHTML = "Početna";
        button.onclick = (ev) => this.drawWelcome();
        buttons.appendChild(button);

        button = document.createElement("button");
        button.classList.add("buttonLight");
        button.innerHTML = "Katalog";
        button.onclick = (ev) => this.drawCatalog();
        buttons.appendChild(button);

        button = document.createElement("button");
        button.classList.add("buttonLight");
        button.innerHTML = "Login";
        button.onclick = (ev) => this.drawLogin();
        buttons.appendChild(button);
       
        button = document.createElement("button");
        button.classList.add("buttonLight");
        button.innerHTML = "Kreiraj nalog";
        button.onclick = (ev) => this.drawAccountCreation();
        buttons.appendChild(button);
        
    }
    drawContent(){
        this.mainContent = document.createElement("div");
        this.mainContent.classList.add("mainContent"); 
        this.mainContainer.appendChild(this.mainContent);
        this.drawWelcome();
        
    }
    
    drawWelcome(){
        let content = this.removeContent();
        content.classList.add("contentWelcome");

        let title = document.createElement("label");
        title.classList.add("titleWelcome");
        title.innerHTML = "Dobrodošli na WebStore 17463!";
        content.appendChild(title);

        let description = document.createElement("p");
        description.classList.add("descriptionWelcome");
        description.innerHTML = "Preko 20.000 artikala &#129313 - laptop i desktop računari, telefoni, televizori, bela tehnika, mali kućni aparati, alati. Kupovina na rate bez kamate!"
        content.appendChild(description);

        let button = document.createElement("button");
        button.classList.add("buttonDark");
        button.classList.add("welcomeButton");
        button.onclick = (ev) => this.drawCatalog();
        button.innerHTML = "Katalog";
        content.appendChild(button);

    }


    drawCatalog(){ 
        var categories = [                 
            "Svi proizvodi",
            "Procesor",
            "Grafička kartica",
            "RAM memorija"
        ];
        
        let header = [                 
            "Izbor",
            "Serijski broj",
            "Proizvod",
            "Kategorija",
            "Cena"
        ]; 
        
        let content = this.removeContent();
        content.classList.add("contentCatalog");

        let catalogBox = document.createElement("div");
        catalogBox.classList.add("catalogBoxDIV");
        content.appendChild(catalogBox);

        // LEFT DIV
        let catalog = document.createElement("div");
        catalog.classList.add("catalogDIV");
        catalogBox.appendChild(catalog);
        
        // RIGHT DIV
        let userAcc = document.createElement("div");
        userAcc.classList.add("userDIV");
        catalogBox.appendChild(userAcc);

        // LEFT DIV - CATEGORY 
        let categorySelect = document.createElement("div");
        categorySelect.classList.add("categoryDIV");
        catalog.appendChild(categorySelect);

        let selectBox = document.createElement("select");
        selectBox.classList.add("catalogSelect");
        categorySelect.appendChild(selectBox);

        let optionCategory;

        categories.forEach( cat => {
            optionCategory = document.createElement("option");
            optionCategory.innerHTML = cat;
            optionCategory.value = cat;
            selectBox.appendChild(optionCategory);
        })
        
        // LEFT DIV - CATEGORY - BUTTON
        let button = document.createElement("button");
        button.innerHTML = "Učitaj";
        button.classList.add("buttonDark");
        button.classList.add("categoryButton")
        button.onclick = (ev) => this.drawCatalogTable(tableBody, catalog.querySelector('option:checked').value);
        categorySelect.appendChild(button);

        // LEFT DIV - TABLE
        var table = document.createElement("table");
        table.classList.add("catalogTable");
        catalog.appendChild(table);

        var tableHead = document.createElement("thead");
        table.appendChild(tableHead);

        let tr = document.createElement("tr");
        tableHead.appendChild(tr);

        let th;
        
        header.forEach( el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        var tableBody = document.createElement("tbody");
        tableBody.classList.add("tableBody");
        table.appendChild(tableBody);

        // RIGHT DIV - INPUT FORM
        let label = document.createElement("label");
        label.classList.add("catalogFormTitle");
        label.innerHTML = "Forma za kupovinu";
        userAcc.appendChild(label);


        // RIGHT DIV - INPUT FORM - SELECT STORE
        let selectStoreBox = document.createElement("select");
        selectStoreBox.classList.add("storeSelect");
        userAcc.appendChild(selectStoreBox);

        // LOAD STORE
        this.fetchAllStores(selectStoreBox);

        let nameInput = document.createElement("input");
        nameInput.classList.add("catalogInputFields");
        nameInput.classList.add("nameCatalogInput");
        nameInput.type = "text";
        nameInput.placeholder = " Ime";
        userAcc.appendChild(nameInput);

        let lastNameInput = document.createElement("input");
        lastNameInput.classList.add("catalogInputFields");
        lastNameInput.classList.add("lastNameCatalogInput");
        lastNameInput.type = "text";
        lastNameInput.placeholder = " Prezime";
        userAcc.appendChild(lastNameInput);

        let mailInput = document.createElement("input");
        mailInput.classList.add("catalogInputFields");
        mailInput.classList.add("mailCatalogInput");
        mailInput.type = "text";
        mailInput.placeholder = " Email";
        userAcc.appendChild(mailInput);

        let quantityInput = document.createElement("input");
        quantityInput.classList.add("catalogInputFields");
        quantityInput.classList.add("quantityCatalogInput");
        quantityInput.type = "number";
        quantityInput.placeholder = " Količina";
        userAcc.appendChild(quantityInput); 

        // RIGHT DIV - CONFIRM ORDER BUTTON
        let buyButton = document.createElement("button");
        buyButton.classList.add("buttonDark");
        buyButton.classList.add("catalogBuyButton");
        buyButton.innerHTML = "Naruči";
        userAcc.appendChild(buyButton);        

        buyButton.onclick = (ev) => this.confirmOrder(nameInput.value, lastNameInput.value, mailInput.value, quantityInput.value, this.partsArray);
    }

    fetchAllStores(host){
        fetch("https://localhost:5001/PCStore/ReturnAllStores", {method: "GET"})
        .then(s => {
            if(s.ok){
                s.json().then( data => {
                    data.forEach( store => {
                        let str = new PCStore(store.id, store.name, store.storePhoneNumber, store.storeLocation, store.storeMailAdress);
                        str.draw(host);
                    })
                })
            }
        })
    }

    drawCatalogTable(body, value){
        fetch("https://localhost:5001/PCPart/ReturnAllParts", { method: "GET"})
        .then(p => {
            if(p.ok){
                var hostNew = this.deletePartsFromTable();
                p.json().then(data => {
                    data.forEach( p => {
                        if(value === "Svi proizvodi"){
                            let part = new PCPart(p.id, p.serialNumber, p.productName, p.productCategory, p.price);
                            this.partsArray.push(part);
                            part.draw(hostNew);
                        }
                        else if(p.productCategory === value){
                            let part = new PCPart(p.id, p.serialNumber, p.productName, p.productCategory, p.price);
                            this.partsArray.push(part);
                            part.draw(hostNew);
                        }
                    })
                })
            }
        })
    }

    deletePartsFromTable()
    {
    
        let tbody = document.querySelector(".tableBody");
        let table = document.querySelector(".catalogTable");
        if(tbody != null)
            table.removeChild(tbody);
        tbody = document.createElement("tbody");
        tbody.classList.add("tableBody");
        table.appendChild(tbody);
        return tbody;
    }

    confirmOrder(name, lastname, mail, orderQty, arr){
        console.log(arr);
        if(document.querySelector('input[name = proizvodi]:checked').value == null){
            alert("Proizvod nije izabran!");
            return;
        }
        if(name === "" || lastname === "" || mail === "" || orderQty < 1){
            alert("Pogrešno popunjena forma, pokušajte ponovo!");
            return;
        }
        if(arr.length === 0){
            alert("array error!");
            return;
        }
        let orderid;
        let userid;
        let partid = document.querySelector('input[name = proizvodi]:checked').value;
        let storeid = document.querySelector('.optionStore:checked').value;
        let price;
        arr.forEach( element => {
            if(element.id == partid)
                price = element.price * orderQty;
        })


        fetch("https://localhost:5001/UserAccount/ReturnAccountWithOrders/"+name+"/"+lastname+"/"+mail, { method: "GET" })
        .then( u => {
            if(u.ok){
                u.json().then(data => {
                    userid = data[0].id;
                    console.log(userid);
                    fetch("https://localhost:5001/Order/AddOrder/"+orderQty+"/"+price+"/"+userid+"/"+partid+"/"+storeid, { method: "POST",
                    headers:{
                        "Content-Type": "application/json"
                    }})
                    .then(o => {
                        if(o.ok){
                            o.json().then( data2 => {
                                orderid = data2;
                                console.log(data2);
                                fetch("https://localhost:5001/UserAccount/UpdateUserAccountNewOrder/"+userid+"/"+orderid, { method: "PUT"})
                                .then( u2 => {
                                    if(u2.ok){
                                        alert("Porudžbina je uspešno poslata serveru!");
                                    }
                                })
                            })
                        }
                    })    
                })
            }
        })
    }

    drawAccountCreation(){
        let content = this.removeContent();
        content.classList.add("contentAccountCreation");

        let accountCreation = document.createElement("div");
        accountCreation.classList.add("accCreationDIV");
        content.appendChild(accountCreation);

        // CREATION DIV

        let label = document.createElement("label");
        label.classList.add("accCreationTitle");
        label.innerHTML = "Kreiraj nalog:";
        accountCreation.appendChild(label);

        let nameInput = document.createElement("input");
        nameInput.classList.add("accInputFields");
        nameInput.classList.add("nameInput");
        nameInput.type = "text";
        nameInput.placeholder = " Ime";
        accountCreation.appendChild(nameInput);

        let lastNameInput = document.createElement("input");
        lastNameInput.classList.add("accInputFields");
        lastNameInput.classList.add("lastNameInput");
        lastNameInput.type = "text";
        lastNameInput.placeholder = " Prezime";
        accountCreation.appendChild(lastNameInput);

        let cityInput = document.createElement("input");
        cityInput.classList.add("accInputFields");
        cityInput.classList.add("cityInput");
        cityInput.type = "text";
        cityInput.placeholder = " Grad";
        accountCreation.appendChild(cityInput);

        let addressInput = document.createElement("input");
        addressInput.classList.add("accInputFields");
        addressInput.classList.add("addressInput");
        addressInput.type = "text";
        addressInput.placeholder = " Adresa";
        accountCreation.appendChild(addressInput);

        let postalInput = document.createElement("input");
        postalInput.classList.add("accInputFields");
        postalInput.classList.add("postalInput");
        postalInput.type = "text";
        postalInput.placeholder = " Poštanski broj";
        accountCreation.appendChild(postalInput);

        let phoneInput = document.createElement("input");
        phoneInput.classList.add("accInputFields");
        phoneInput.classList.add("phoneInput");
        phoneInput.type = "text";
        phoneInput.placeholder = " Telefon";
        accountCreation.appendChild(phoneInput);

        let mailInput = document.createElement("input");
        mailInput.classList.add("accInputFields");
        mailInput.classList.add("mailInput");
        mailInput.type = "text";
        mailInput.placeholder = " Email";
        accountCreation.appendChild(mailInput);

        // CREATION OPTIONS

        let accCreationButton = document.createElement("button");
        accCreationButton.classList.add("buttonDark");
        accCreationButton.classList.add("accCreationButton");
        accCreationButton.innerHTML = "Registruj se";
        accountCreation.appendChild(accCreationButton);
        accCreationButton.onclick = (ev) => this.addUserAccount(
            nameInput.value,
            lastNameInput.value,
            cityInput.value,
            addressInput.value,
            postalInput.value,
            phoneInput.value,
            mailInput.value
        );
    }

    addUserAccount(...args){
        if(args.every(arg => {
            if(arg == ""){
                alert("Potrebno je popuniti sva polja!");
                return false;
            }
            return true;
        })) 
        {   // CONDITION MET
            fetch("https://localhost:5001/UserAccount/AddUserAccount",{
                method: "POST",
                headers:{
                    "Content-Type": "application/json"
                },
                body:JSON.stringify({
                    "firstName": args[0],
                    "lastName": args[1],
                    "city": args[2],
                    "address": args[3],
                    "postalCode": parseInt(args[4]),
                    "phoneNumber": parseInt(args[5]),
                    "mailAddress": args[6]  
                })
            })
            .then( s => {
                if(s.ok){
                    alert("Korisnički nalog je kreiran!");
                    this.drawLogin();
                }
                else if(s.status == 400){
                    s.json().then(s => console.log(s.message));
                }
            })
        }
    }

    drawLogin(){
        let content = this.removeContent();
        content.classList.add("contentLogin");

        let loginForm = document.createElement("div");
        loginForm.classList.add("loginFormDIV");
        content.appendChild(loginForm);

        let label = document.createElement("label");
        label.classList.add("loginFormTitle");
        label.innerHTML = "Prijava";
        loginForm.appendChild(label);

        let nameInput = document.createElement("input");
        nameInput.classList.add("loginInputFields");
        nameInput.classList.add("nameLoginInput");
        nameInput.type = "text";
        nameInput.placeholder = " Ime";
        loginForm.appendChild(nameInput);

        let lastNameInput = document.createElement("input");
        lastNameInput.classList.add("loginInputFields");
        lastNameInput.classList.add("lastNameLoginInput");
        lastNameInput.type = "text";
        lastNameInput.placeholder = " Prezime";
        loginForm.appendChild(lastNameInput);

        let mailInput = document.createElement("input");
        mailInput.classList.add("loginInputFields");
        mailInput.classList.add("mailInput");
        mailInput.type = "text";
        mailInput.placeholder = " Email";
        loginForm.appendChild(mailInput);

        let loginButton = document.createElement("button");
        loginButton.classList.add("buttonDark");
        loginButton.classList.add("loginButton");
        loginButton.innerHTML = "Prijavi se";
        loginForm.appendChild(loginButton);
        loginButton.onclick = (ev) => this.fetchUserData(nameInput.value, lastNameInput.value, mailInput.value);
    }

    fetchUserData(name, lastname, mail){
        fetch("https://localhost:5001/UserAccount/ReturnAccountWithOrders/"+name+"/"+lastname+"/"+mail, { method: "GET"})
        .then( u => {
            if(u.ok){
                u.json().then( (data) => {
                    let d = data[0];
                    let userFromBase = new UserAccount(d.id, d.firstName, d.lastName, d.city, d.address, d.postalCode, d.phoneNumber, d.mailAddress);
                    let part; let store; let order;
                    d.orders.forEach( o => {
                        part = new PCPart(o.part.id, o.part.serialNumber, o.part.productName, o.part.productCategory, o.part.price);
                        store = new PCStore(o.fromStore.id, o.fromStore.name, o.fromStore.storePhoneNumber, o.fromStore.storeLocation, o.fromStore.storeMailAdress);
                        order = new Order(o.id, o.quantity, o.price);
                        order.addPartAndStore(part, store);
                        userFromBase.addOrder(order);
                    })
                    this.drawUserData(userFromBase);
                })
            }
            else{
                alert("Greška pri pribavljanju podataka!");
                this.drawLogin();
            }
        })
    }        

    drawUserData(user){
        let dbUser = user;
        let content = this.removeContent();
        content.classList.add("contentUserData");

        // ACCOUNT INFO

        let userInfo = document.createElement("div");
        userInfo.classList.add("userInfoDIV");
        content.appendChild(userInfo);

        let table = document.createElement("table");
        table.classList.add("accountTable");
        userInfo.appendChild(table);

        let tableHead = document.createElement("thead");
        table.appendChild(tableHead);

        let tr = document.createElement("tr");
        tableHead.appendChild(tr);

        let th;
        var header = ["Ime", "Prezime", "Grad", "Adresa", "Poštanski broj", "Telefon", "Mail adresa"];
        header.forEach( el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        });

        let tableBody = document.createElement("tbody");
        tableBody.classList.add("tableBody");
        table.appendChild(tableBody);
        dbUser.drawTable(tableBody);


        // ORDERS

        table = document.createElement("table");
        table.classList.add("accountOrdersTable");
        userInfo.appendChild(table);

        tableHead = document.createElement("thead");
        table.appendChild(tableHead);

        tr = document.createElement("tr");
        tableHead.appendChild(tr);

        var header = ["Proizvod", "Prodajno mesto", "Količina", "Ukupno"];
        header.forEach( el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        });

        tableBody = document.createElement("tbody");
        tableBody.classList.add("tableBody");
        table.appendChild(tableBody);
        dbUser.orders.forEach( o => o.draw(tableBody));

        //---------------------------------------------------

        let button = document.createElement("button");
        button.classList.add("buttonDark");
        button.classList.add("removeAccountButton");
        button.innerHTML = "Obriši nalog";
        button.onclick = (ev) => this.removeAccount(dbUser.id);
        userInfo.appendChild(button);
    }
    removeAccount(id){
        fetch("https://localhost:5001/UserAccount/DeleteUserAccount/"+id, { method: "DELETE"})
            .then( u => {
                if(u.ok){
                    alert("Nalog je uspešno obrisan!");
                    this.drawLogin();
                }
                else{
                    alert("Došlo je do greške!");
                }
            })
    }

    removeContent(){
        let content = document.querySelector(".content");
        if(content != null){
            this.mainContent.removeChild(content);
        }
        content = document.createElement("div");
        content.classList.add("content");
        this.mainContent.appendChild(content);
        return content;            
    }

    drawFooter(){
        this.footer = document.createElement("footer");
        this.mainContainer.appendChild(this.footer);

        let footerInfo = document.createElement("label");
        footerInfo.classList.add("footerInfo");
        footerInfo.innerHTML = "Milan Stojanovski 17463"
        this.footer.appendChild(footerInfo);

        footerInfo = document.createElement("label");
        footerInfo.classList.add("footerInfo");
        footerInfo.innerHTML = "©  ELEKTRONSKI FAKULTET U NIŠU 2022. SVA PRAVA ZADRŽANA."
        this.footer.appendChild(footerInfo);

        footerInfo = document.createElement("label");
        footerInfo.classList.add("footerInfo");
        footerInfo.innerHTML = " UNIVERZITET U NIŠU."
        this.footer.appendChild(footerInfo);
    }
}