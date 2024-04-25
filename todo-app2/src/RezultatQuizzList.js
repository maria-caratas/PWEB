import React, { useEffect, useState } from 'react';

const RezultatQuizzList = ({ onEdit, onDelete }) => {
    const [rezultate, setRezultate] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('/api/RezultatQuizz');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setRezultate(data);
            } catch (error) {
                console.error('Error fetching data: ', error);
            }
        };

        fetchData();
    }, []);

    const handleDelete = async (id) => {
        try {
            const response = await fetch(`/api/RezultatQuizz/${id}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            setRezultate(rezultate.filter(rezultat => rezultat.rezultatQuizzId !== id));
        } catch (error) {
            console.error('Error deleting rezultat: ', error);
        }
    };

    return (
        <div>
            <h2>Lista Rezultate Quizz</h2>
            {rezultate.map((rezultat) => (
                <div key={rezultat.rezultatQuizzId}>
                    <p>Utilizator ID: {rezultat.utilizatorId}</p>
                    <p>Intrebare ID: {rezultat.intrebareId}</p>
                    <p>Scor obtinut: {rezultat.scorObtinut}</p>
                    <button onClick={() => onEdit(rezultat)}>Edit</button>
                    <button onClick={() => handleDelete(rezultat.rezultatQuizzId)}>Delete</button>
                </div>
            ))}
        </div>
    );
};

export default RezultatQuizzList;
