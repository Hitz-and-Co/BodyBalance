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
        const response = await fetch('http://localhost:5000/api/BodyBalance/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Fehler beim Abrufen der Ergebnisse: ${errorText}`);
        }

        const data = await response.json();

        const bmi = data.bmi || 0;
        const tdee = data.tdee || 0;
        const bmiFeedback = data["bmI_Feedback"] || 'Kein Feedback verfügbar.';
        const tdeeFeedback = data["tdeE_Feedback"] || 'Kein Feedback verfügbar.';

        resultsDiv.style.display = 'block';
        errorDiv.style.display = 'none';

        resultsDiv.innerHTML = `
            <h3>Ergebnisse</h3>
            <p><strong>BMI:</strong> ${bmi.toFixed(2)}</p>
            <p><strong>BMI-Feedback:</strong> ${bmiFeedback}</p>
            <p><strong>TDEE:</strong> ${tdee.toFixed(2)} kcal</p>
            <p><strong>TDEE-Feedback:</strong> ${tdeeFeedback}</p>
        `;
    } catch (error) {
        resultsDiv.style.display = 'none';
        errorDiv.style.display = 'block';
        errorDiv.textContent = error.message;
    }
});
