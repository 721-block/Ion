import React from 'react';
import { Link } from 'react-router-dom';
import './Header.css'
import IONLogo from '../../assets/images/ion-logo.png'

const Header = () => {
    return (
        <div className="header">
            <Link to="/" className="logo-link">
                <img src={IONLogo} alt="ION" width="150" />
            </Link>
            <div className="user-buttons">
                <Link to="/chats" className="chats-link">Мои чаты</Link>
                <Link to="/profile" className="profile-link">
                    <img src="http://721block.ru:5000/images/1/1.png" alt="Фото профиля" width="50" />
                    <p>Юдзи Итадори</p>
                </Link>
            </div>
        </div>
    );
};

export default Header; 