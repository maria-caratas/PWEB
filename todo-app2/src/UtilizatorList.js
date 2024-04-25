import React, { useEffect, useState } from 'react';

const UtilizatorList = ({ onEdit, onDelete }) => {
    const [utilizatori, setUtilizatori] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('/api/Utilizator');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setUtilizatori(data);
            } catch (error) {
                console.error('Error fetching data: ', error);
            }
        };

        fetchData();
    }, []);

    const handleDelete = async (id) => {
        try {
            const response = await fetch(`/api/Utilizator/${id}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            setUtilizatori(utilizatori.filter(utilizator => utilizator.utilizatorId !== id));
        } catch (error) {
            console.error('Error deleting utilizator: ', error);
        }
    };

    return (
        <div>
            <h2>Lista Utilizatori</h2>
            {utilizatori.map((utilizator) => (
                <div key={utilizator.utilizatorId}>
                    <p>Nume Utilizator: {utilizator.numeUtilizator}</p>
                    <p>Rol: {utilizator.rol}</p>
                    <button onClick={() => onEdit(utilizator)}>Edit</button>
                    <button onClick={() => handleDelete(utilizator.utilizatorId)}>Delete</button>
                </div>
            ))}
        </div>
    );
};

export default UtilizatorList;
