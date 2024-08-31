import React, { useState, useEffect } from 'react';
import { fetchBillboards, createBillboard } from '../services/reservationService';

const AdminCartelera: React.FC = () => {
    const [billboards, setBillboards] = useState<any[]>([]);
    const [newBillboard, setNewBillboard] = useState<string>('');

    useEffect(() => {
        const getBillboards = async () => {
            const fetchedBillboards = await fetchBillboards();
            setBillboards(fetchedBillboards);
        };

        getBillboards();
    }, []);

    const handleAddBillboard = async () => {
        await createBillboard(newBillboard);
        setBillboards([...billboards, { name: newBillboard }]);
        setNewBillboard('');
    };

    return (
        <div>
            <h1>Admin de Carteleras</h1>
            <input
                type="text"
                value={newBillboard}
                onChange={(e) => setNewBillboard(e.target.value)}
                placeholder="Nombre de la nueva cartelera"
            />
            <button onClick={handleAddBillboard}>Agregar Cartelera</button>
            <ul>
                {billboards.map(billboard => (
                    <li key={billboard.id}>{billboard.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default AdminCartelera;