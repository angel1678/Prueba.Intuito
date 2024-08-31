export const fetchSeats = async () => {
    const response = await fetch('https://localhost:44350/api/Seats');
    if (!response.ok) throw new Error('Failed to fetch seats');
    return response.json();
};

export const updateSeat = async (seatId: number, status: boolean) => {
    const response = await fetch(`https://localhost:44350/api/Seats/update/${seatId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ status })
    });
    if (!response.ok) throw new Error('Failed to update seat');
    return response.json();
};

export const fetchBillboards = async () => {
    const response = await fetch('https://localhost:44350/api/Billboards');
    if (!response.ok) throw new Error('Failed to fetch billboards');
    return response.json();
};

export const createBillboard = async (name: string) => {
    const response = await fetch('https://localhost:44350/api/Billboards', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name })
    });
    if (!response.ok) throw new Error('Failed to create billboard');
    return response.json();
};

export const fetchReservations = async () => {
    try {
    const response = await fetch('https://localhost:44350/api/Reservations');
    if (!response.ok) throw new Error('Failed to fetch reservations');
        return response.json();
    } catch (error) {
        console.error('Error fetchReservations:', error);
    }
};
export const disableSeat = async (seatId: number) => {
    try {

        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        const raw = JSON.stringify(seatId);

        const requestOptions: RequestInit = {
            method: "POST",
            headers: myHeaders,
            body: raw,
            redirect: "follow" 
        };

        fetch("https://localhost:7173/api/Seats/disable-seat", requestOptions)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.text(); 
            })
            .then((result) => console.log(result))
            .catch((error) => console.error('Error:', error));
    } catch (error) {
        console.error('Error disabling seat:', error);
    }
};