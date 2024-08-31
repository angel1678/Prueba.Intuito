import React, { useState, useEffect } from 'react';
import { fetchReservations } from '../services/reservationService';

const ReservationList: React.FC = () => {
    const [reservations, setReservations] = useState<any[]>([]);

    useEffect(() => {
        const getReservations = async () => {
            const fetchedReservations = await fetchReservations();
            setReservations(fetchedReservations);
        };

        getReservations();
    }, []);

    return (
        <div>
            <h1>Lista de Reservas</h1>
            <ul>
                {reservations.map(reservation => (
                    <li key={reservation.id}>
                        {reservation.customerName} - {reservation.seatNumber} - {reservation.status ? 'Confirmada' : 'Pendiente'}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ReservationList;