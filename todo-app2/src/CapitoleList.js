import React, { useEffect, useState } from 'react';

const CapitoleList = ({ onEdit, onDelete }) => {
    const [capitole, setCapitole] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('/api/Capitole');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setCapitole(data);
            } catch (error) {
                console.error('Error fetching data: ', error);
            }
        };

        fetchData();
    }, []);

    const handleDelete = async (id) => {
        try {
            const response = await fetch(`/api/Capitole/${id}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            setCapitole(capitole.filter(capitol => capitol.capitolInvatareId !== id));
        } catch (error) {
            console.error('Error deleting capitol: ', error);
        }
    };

    return (
        <div>
            <h2>Lista Capitole</h2>
            {capitole.map((capitol) => (
                <div key={capitol.capitolInvatareId}>
                    <h3>{capitol.titlu}</h3>
                    <p>{capitol.continut}</p>
                    <button onClick={() => onEdit(capitol)}> Edit</button>
                    <button onClick={() => handleDelete(capitol.capitolInvatareId)}> Delete</button>
                </div>
            ))}
        </div>
    );
};

export default CapitoleList;