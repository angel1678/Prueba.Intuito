import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AdminButaca from './components/AdminButaca';
import AdminCartelera from './components/AdminCartelera';
import ReservationList from './components/ReservationList';
import { ReservationProvider } from './context/ReservationContext';


const App: React.FC = () => {
    return (
        <ReservationProvider>
            <Router>
                <div className="container mx-auto p-4">
                    <Routes>
                        <Route path="/" element={<ReservationList />} />
                        <Route path="/admin-butaca" element={<AdminButaca />} />
                        <Route path="/admin-cartelera" element={<AdminCartelera />} />
                    </Routes>
                </div>
            </Router>
        </ReservationProvider>
    );
};

export default App;