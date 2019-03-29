const product = document.querySelector('.title');

fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {
        const data = json;
                console.log(data);
        data.forEach(item => {
            product.innerHTML += `<p> ${data[0]['name']} </p>`;
        });
    });
