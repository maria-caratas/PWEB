import React, { useEffect, useState } from 'react';

const IntrebariList = ({ onEdit, onDelete }) => {
    const [intrebari, setIntrebari] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('/api/Intrebari');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setIntrebari(data);
            } catch (error) {
                console.error('Error fetching data: ', error);
            }
        };

        fetchData();
    }, []);

    const handleDelete = async (id) => {
        try {
            const response = await fetch(`/api/Intrebari/${id}`, {
                method: 'DELETE',
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            setIntrebari(intrebari.filter(intrebare => intrebare.intrebareId !== id));
        } catch (error) {
            console.error('Error deleting intrebare: ', error);
        }
    };

    return (
        <div>
            <h2>Lista Intrebari</h2>
            {intrebari.map((intrebare) => (
                <div key={intrebare.intrebareId}>
                    <h3>{intrebare.textIntrebare}</h3>
                    <ul>
                        {intrebare.optiuniRaspuns.map((optiune, index) => (
                            <li key={index}>{optiune}</li>
                        ))}
                    </ul>
                    <p>Raspuns corect: {intrebare.optiuniRaspuns[intrebare.raspunsCorect]}</p>
                    <button onClick={() => onEdit(intrebare)}>Edit</button>
                    <button onClick={() => handleDelete(intrebare.intrebareId)}>Delete</button>
                </div>
            ))}
        </div>
    );
};

export default IntrebariList;
