import React, { createContext, useContext, useState } from 'react';

interface Reservation {
    id: number;
    customerName: string;
    seatNumber: string;
    status: boolean;
}

interface ReservationContextType {
    reservations: Reservation[];
    setReservations: React.Dispatch<React.SetStateAction<Reservation[]>>;
}

const ReservationContext = createContext<ReservationContextType | undefined>(undefined);

export const ReservationProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [reservations, setReservations] = useState<Reservation[]>([]);

    return (
        <ReservationContext.Provider value={{ reservations, setReservations }}>
            {children}
        </ReservationContext.Provider>
    );
};

export const useReservationContext = () => {
    const context = useContext(ReservationContext);
    if (!context) {
        throw new Error('useReservationContext must be used within a ReservationProvider');
    }
    return context;
};