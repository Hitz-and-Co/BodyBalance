const form = document.getElementById('userForm');
const resultsDiv = document.getElementById('results');
const errorDiv = document.getElementById('error');

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    const userData = {
        height: parseFloat(form.height.value),
        weight: parseFloat(form.weight.value),
        age: parseInt(form.age.value, 10),
        gender: form.gender.value,
        activityLevel: form.activityLevel.value
    };

    try {
        const response = await fetch('http://localhost:5144/api/BodyBalance/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        });

        if (!response.ok) {
            throw new Error('Fehler beim Abrufen der Ergebnisse');
        }

        const data = await response.json();
        resultsDiv.style.display = 'block';
        errorDiv.style.display = 'none';

        resultsDiv.innerHTML = `
            <h3>Ergebnisse</h3>
            <p><strong>BMI:</strong> ${data.bmi.toFixed(2)}</p>
            <p>${data.bmi_Feedback || 'Kein Feedback verfügbar.'}</p>
            <p><strong>TDEE:</strong> ${data.tdee.toFixed(2)} kcal</p>
            <p>${data.tdee_Feedback || 'Kein Feedback verfügbar.'}</p>
        `;
    } catch (error) {
        resultsDiv.style.display = 'none';
        errorDiv.style.display = 'block';
        errorDiv.textContent = error.message;
    }
});
