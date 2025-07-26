// Nạp file HTML vào phần tử có ID tương ứng
function loadHTML(id, file) {
    fetch(file)
        .then(response => response.text())
        .then(data => document.getElementById(id).innerHTML = data)
        .catch(error => console.error("Lỗi khi tải file:", error));
}

// Gọi function để tải header và dropdown

loadHTML("footer", "module/footer.html");
loadHTML("dropdown", "module/index_m/dropdown.html");

