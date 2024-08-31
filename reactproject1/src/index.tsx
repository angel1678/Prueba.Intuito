import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './App';
import ReservationList from './components/ReservationList';
import AdminButaca from './components/AdminButaca';
import AdminCartelera from './components/AdminCartelera';

const root = ReactDOM.createRoot(document.getElementById('root')!);

root.render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<ReservationList />} />
                <Route path="/admin-butaca" element={<AdminButaca />} />
                <Route path="/admin-cartelera" element={<AdminCartelera />} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);