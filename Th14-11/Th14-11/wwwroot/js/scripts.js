// Kiểm tra JS có load không
console.log("Template JS loaded!");

// Highlight hàng trong bảng khi click
document.addEventListener("DOMContentLoaded", () => {
    const rows = document.querySelectorAll("table.table tbody tr");
    rows.forEach(row => {
        row.addEventListener("click", () => {
            rows.forEach(r => r.classList.remove("selected"));
            row.classList.add("selected");
        });
    });
});
document.body.style.backgroundColor = "lightblue";
console.log("✅ JS đang chạy ngon lành!");
