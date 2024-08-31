import React from 'react';
import { useForm } from 'react-hook-form';
import { disableSeat } from '../services/reservationService';

function AdminButaca() {
  const { register, handleSubmit } = useForm();

    const onSubmit = async (data: any) => {
    try {
      await disableSeat(data.bookingId);
      alert('Butaca inhabilitada y reserva cancelada');
    } catch (error: unknown) {
        if (error instanceof Error) {
            console.error(error.message);
        } else {
            console.error('An unknown error occurred');
        }
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register('bookingId')} placeholder="ID de la Reserva" />
      <button type="submit">Inhabilitar Butaca</button>
    </form>
  );
}

export default AdminButaca;