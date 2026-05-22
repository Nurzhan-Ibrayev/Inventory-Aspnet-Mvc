document.addEventListener("DOMContentLoaded", function () {
    const selectAll = document.getElementById("selectAll");
    const checkboxes = document.querySelectorAll(".select-item");
    const toolbar = document.getElementById("toolbar");
    const rows = document.querySelectorAll(".inventory-row");

    // Функция обновления тулбара
    function updateToolbar() {
        const checkedCount = document.querySelectorAll(".select-item:checked").length;
        if (checkedCount > 0) {
            toolbar.classList.remove("d-none");
        } else {
            toolbar.classList.add("d-none");
        }
    }

    // Выбор всех
    selectAll.addEventListener("change", function () {
        checkboxes.forEach(cb => {
            cb.checked = this.checked;
            cb.closest("tr").classList.toggle("selected", this.checked);
        });
        updateToolbar();
    });

    // Выбор отдельной строки
    checkboxes.forEach(cb => {
        cb.addEventListener("change", function (e) {
            this.closest("tr").classList.toggle("selected", this.checked);
            updateToolbar();
            e.stopPropagation(); // Чтобы не срабатывал клик по строке
        });
    });

    // Клик по всей строке (кроме чекбокса) ведет на страницу деталей
    rows.forEach(row => {
        row.addEventListener("click", function (e) {
            if (e.target.type !== 'checkbox') {
                const link = this.querySelector("td a").getAttribute("href");
                window.location.href = link;
            }
        });
    });
});