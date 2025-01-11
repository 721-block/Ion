import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Index from './pages/Index';
import Announce from './pages/Announce';
import Chats from './pages/Chats';
import OwnerProfile from './pages/OwnerProfile';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Index/>}/>
        <Route path="/announcement/:announcementId" element={<Announce/>} />
        <Route path="/user/:userId" element={<OwnerProfile/>} />
        <Route path="/chats" element={<Chats/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;