import React, { useState } from 'react';

const CapitolForm = ({ onSubmit, initialCapitol }) => {
    const [capitol, setCapitol] = useState(initialCapitol || { titlu: '', continut: '' });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCapitol({ ...capitol, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`/api/Capitole${initialCapitol ? `/${initialCapitol.capitolInvatareId}` : ''}`, {
                method: initialCapitol ? 'PUT' : 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(capitol),
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            onSubmit(capitol);
            setCapitol({ titlu: '', continut: '' });
        } catch (error) {
            console.error('Error submitting data: ', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Titlu:
                <input type="text" name="titlu" value={capitol.titlu || ''} onChange={handleChange} />
            </label>
            <label>Continut:
                <textarea name="continut" value={capitol.continut || ''} onChange={handleChange} />
            </label>
            <button type="submit">Salveaza</button>
        </form>
    );
};

export default CapitolForm;
