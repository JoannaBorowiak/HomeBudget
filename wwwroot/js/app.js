document.addEventListener('DOMContentLoaded', () => {
    const incomeTab = document.getElementById('incomeTab');
    const expenseTab = document.getElementById('expenseTab');
    const submitButton = document.getElementById('submitButton');
    const transactionForm = document.getElementById('transactionForm');
    const categorySelect = document.getElementById('category');
    const incomesTable = document.getElementById('incomesTable').getElementsByTagName('tbody')[0];
    const expensesTable = document.getElementById('expensesTable').getElementsByTagName('tbody')[0];

    let currentTransactionType = 'income'; // domyślnie przychód

    // Funkcja do ładowania kategorii
    async function loadCategories() {
        try {
            const response = await fetch('/api/kategorie');  // Pobieranie kategorii z API
            const categories = await response.json();

            categorySelect.innerHTML = ''; // Wyczyść istniejące opcje w select

            // Dodaj opcje do select
            categories.forEach(category => {
                const option = document.createElement('option');
                option.value = category.id;  // Użyj ID jako wartości
                option.textContent = category.nazwa;  // Użyj nazwy kategorii
                categorySelect.appendChild(option);  // Dodaj opcję do select
            });
        } catch (error) {
            console.error('Błąd podczas ładowania kategorii:', error);
        }
    }

    // Funkcja do ładowania przychodów
    async function loadIncomes() {
        try {
            const response = await fetch('/api/przychody');
            const incomes = await response.json();

            incomesTable.innerHTML = ''; // Wyczyść tabelę

            incomes.forEach(income => {
                const row = incomesTable.insertRow();
                row.innerHTML = `
                    <td>${income.kwota}</td>
                    <td>${income.kategoria.nazwa}</td>
                    <td>${income.opis}</td>
                    <td>${new Date(income.data).toLocaleDateString()}</td>
                `;
            });
        } catch (error) {
            console.error('Błąd podczas ładowania przychodów:', error);
        }
    }

    // Funkcja do ładowania wydatków
    async function loadExpenses() {
        try {
            const response = await fetch('/api/wydatki');
            const expenses = await response.json();

            expensesTable.innerHTML = ''; // Wyczyść tabelę

            expenses.forEach(expense => {
                const row = expensesTable.insertRow();
                row.innerHTML = `
                    <td>${expense.kwota}</td>
                    <td>${expense.kategoria.nazwa}</td>
                    <td>${expense.opis}</td>
                    <td>${new Date(expense.data).toLocaleDateString()}</td>
                `;
            });
        } catch (error) {
            console.error('Błąd podczas ładowania wydatków:', error);
        }
    }

    // Funkcja do dodawania transakcji (przychód lub wydatek)
    transactionForm.addEventListener('submit', async (event) => {
        event.preventDefault();  // Zapobiega przeładowaniu strony
    
        const formData = new FormData(transactionForm);
    
        // Tworzymy obiekt transakcji
        const newTransaction = {
            kwota: parseFloat(formData.get('amount')), // Kwota
            kategoriaId: parseInt(formData.get('category')), // Kategoria (ID kategorii)
            opis: formData.get('description'),
            data: new Date().toISOString()
        };
    
        const isIncome = submitButton.textContent === "Dodaj Przychód";
        const url = isIncome ? '/api/przychody' : '/api/wydatki';
    
        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newTransaction)  // Wysyłamy dane do API
            });
    
            if (response.ok) {
                loadIncomes();
                loadExpenses();
                transactionForm.reset();  // Reset formularza
            } else {
                const errorData = await response.json();  // Pobranie danych błędu z odpowiedzi
                console.error('Błąd przy dodawaniu transakcji:', errorData);
                alert(`Błąd przy dodawaniu transakcji: ${JSON.stringify(errorData.errors)}`);
            }
        } catch (error) {
            console.error('Błąd podczas dodawania transakcji:', error);
        }
    });
    
    

    // Funkcje do przełączania zakładek
    incomeTab.addEventListener('click', () => {
        currentTransactionType = 'income';
        incomeTab.classList.add('active');
        expenseTab.classList.remove('active');
        submitButton.textContent = 'Dodaj Przychód';
        loadIncomes(); // Załaduj przychody
    });

    expenseTab.addEventListener('click', () => {
        currentTransactionType = 'expense';
        expenseTab.classList.add('active');
        incomeTab.classList.remove('active');
        submitButton.textContent = 'Dodaj Wydatek';
        loadExpenses(); // Załaduj wydatki
    });

    // Na początek załaduj obie tabele
    loadCategories(); // Załaduj kategorie
    loadIncomes(); // Załaduj przychody
    loadExpenses(); // Załaduj wydatki
});
