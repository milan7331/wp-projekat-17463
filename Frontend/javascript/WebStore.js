import { PCPart } from "./PCPart.js"

export class WebStore{
    constructor(host){
        this.mainContainer = host;
        this.mainContainer.className = "mainContainer";
        this.mainNavbar = null;
        this.mainContent = null;
        this.footer = null;
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
        let content = this.removeContent();
        content.classList.add("contentCatalog");

        let catalog = document.createElement("div");
        catalog.classList.add("catalogDIV");
        content.appendChild(catalog);
                
        let userAcc = document.createElement("div");
        userAcc.classList.add("userDIV");
        content.appendChild(userAcc);

        //LEVI DIV - TABELA I KATEGORIJE

        let categorySelect = document.createElement("div");
        categorySelect.classList.add("categoryDIV");
        catalog.appendChild(categorySelect);

        var categories = ["Svi proizvodi", "Procesor", "Grafička kartica", "RAM memorija"];

        let selectBox = document.createElement("select");
        selectBox.classList.add("catalogSelect");

        let optionCategory;
        categories.forEach( cat => {
            optionCategory = document.createElement("option");
            optionCategory.innerHTML = cat;
            optionCategory.value = cat;
            selectBox.appendChild(optionCategory);
        })

        categorySelect.appendChild(selectBox);

        let button = document.createElement("button");
        button.innerHTML = "Učitaj";
        button.classList.add("buttonDark");
        button.classList.add("categoryButton")
        button.onclick = (ev) => this.drawCatalogTable(tableBody, catalog.querySelector('option:checked').value)
        categorySelect.appendChild(button);


        var table = document.createElement("table");
        table.classList.add("catalogTable");
        catalog.appendChild(table);

        var tableHead = document.createElement("thead");
        table.appendChild(tableHead);

        let tr = document.createElement("tr");
        tableHead.appendChild(tr);

        

        let th;
        var header = ["Izbor", "Serijski broj", "Proizvod", "Kategorija", "Cena"]
        header.forEach( el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        var tableBody = document.createElement("tbody");
        tableBody.classList.add("tableBody");
        table.appendChild(tableBody);



        //DESNI DIV - FORMA ZA KUPOVINU


        
    }

    drawCatalogTable(host, value){
        console.log(value);
        fetch("https://localhost:5001/PCPart/ReturnAllParts", { method: "GET"})
        .then(p => {
            if(p.ok){
                var hostNew = this.deletePartsFromTable();
                p.json().then(data => {
                    data.forEach( p => {
                        if(value === "Svi proizvodi"){
                            let part = new PCPart(p.id, p.serialNumber, p.productName, p.productCategory, p.price)
                            part.draw(hostNew);
                        }
                        else if(p.productCategory === value){
                            let part = new PCPart(p.id, p.serialNumber, p.productName, p.productCategory, p.price)
                            part.draw(hostNew);
                        }
                        
                    })
                })
            }
        })
    }

    deletePartsFromTable()
    {
        let table = document.querySelector(".catalogTable");
        let tbody = document.querySelector(".tableBody");
        if(tbody != null)
            table.removeChild(tbody);
        tbody = document.createElement("tbody");
        tbody.classList.add("tableBody");
        table.appendChild(tbody);
        return tbody;
    }

    drawAccountCreation(){
        let content = this.removeContent();
        content.classList.add("contentCatalog");

        let accCreation = document.createElement("div");
        
    }

    drawLogin(){

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