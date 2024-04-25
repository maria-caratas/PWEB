import React, { useState } from 'react';

const IntrebariForm = ({ onSubmit, initialIntrebare }) => {
    const [intrebare, setIntrebare] = useState(initialIntrebare || { textIntrebare: '', optiuniRaspuns: [], raspunsCorect: 0 });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setIntrebare({ ...intrebare, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`/api/Intrebari${initialIntrebare ? `/${initialIntrebare.intrebareId}` : ''}`, {
                method: initialIntrebare ? 'PUT' : 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(intrebare),
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            onSubmit(intrebare);
            setIntrebare({ textIntrebare: '', optiuniRaspuns: [], raspunsCorect: 0 });
        } catch (error) {
            console.error('Error submitting data: ', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Text Intrebare:
                <input type="text" name="textIntrebare" value={intrebare.textIntrebare || ''} onChange={handleChange} />
            </label>
            <label>Optiuni Raspuns:
                <input type="text" name="optiuniRaspuns" value={intrebare.optiuniRaspuns.join(',')} onChange={(e) => setIntrebare({ ...intrebare, optiuniRaspuns: e.target.value.split(',') })} />
            </label>
            <label>Raspuns Corect:
                <input type="number" name="raspunsCorect" value={intrebare.raspunsCorect || ''} onChange={handleChange} />
            </label>
            <button type="submit">Salveaza</button>
        </form>
    );
};

export default IntrebariForm;
