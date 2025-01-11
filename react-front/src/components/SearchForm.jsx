import React, { useState } from 'react';
import './SearchForm.css';

const SearchForm = ({ onSearch }) => {
    const [searchData, setSearchData] = useState({
        address: '',
        startDate: '',
        startTime: '',
        endDate: '',
        endTime: '',
        gearboxType: '',
        bodyType: '',
        carName: '',
        minPrice: '',
        maxPrice: ''
    });

    const handleSubmit = (e) => {
        e.preventDefault();
        onSearch(searchData);
    };

    const handleChange = (e) => {
        setSearchData({
            ...searchData,
            [e.target.name]: e.target.value
        });
    };

    return (
        <div className="search-car">
            <form onSubmit={handleSubmit}>
                <div className="search-form">
                    <div className="address-form">
                    <br/><label htmlFor="address">Адрес</label><br/>
                        <select 
                            name="address" 
                            className="address-list"
                            value={searchData.address}
                            onChange={handleChange}
                        >
                            <option value="">Выберите город</option>
                            <option value="Екатеринбург">Екатеринбург</option>
                        </select>
                    </div>
                    
                    <div className="date-form">
                    <br/><label>С какой даты</label><br/>
                        <input 
                            type="date" 
                            name="startDate"
                            value={searchData.startDate}
                            onChange={handleChange}
                        />
                        <input 
                            type="time" 
                            name="startTime"
                            value={searchData.startTime}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="date-form">
                    <br/><label>По какую дату</label><br/>
                        <input 
                            type="date" 
                            name="endDate"
                            value={searchData.endDate}
                            onChange={handleChange}
                        />
                        <input 
                            type="time" 
                            name="endTime"
                            value={searchData.endTime}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="filters-box">
                    <div className="filters">
                        <div className='car-filter'>
                        <select 
                            name="gearboxType"
                            value={searchData.gearboxType}
                            onChange={handleChange}
                        >
                            <option value="">Тип КПП</option>
                            <option value="Mechanic">Механическая</option>
                            <option value="Automatic">Автоматическая</option>
                            <option value="Stepless">Вариатор</option>
                            <option value="Robotic">Робот</option>
                        </select>
                        </div>

                        <div className='car-filter'>
                        <select 
                            name="bodyType"
                            value={searchData.bodyType}
                            onChange={handleChange}
                        >
                            <option value="">Тип кузова</option>
                            <option value="Sedan">Седан</option>
                            <option value="Hatchback">Хэтчбек</option>
                            <option value="Liftback">Лифтбек</option>
                            <option value="Universal">Универсал</option>
                            <option value="Pickup">Пикап</option>
                            <option value="Minivan">Минивэн</option>
                            <option value="Crossover">Кроссовер</option>
                            <option value="Offroad">Внедорожник</option>
                            <option value="Coupe">Купе</option>
                            <option value="Roadster">Родстер</option>
                            <option value="Cabriolet">Кабриолет</option>
                        </select>
                        </div>

                        <div className='car-filter'>
                        <select 
                            name="carName"
                            value={searchData.carMark}
                            onChange={handleChange}
                        >
                            <option value="">Марка машины</option>
                            <option value="Lada">Lada</option>
                            <option value="Mercedes">Mercedes</option>
                            <option value="Jaguar">Jaguar</option>
                        </select>
                        </div>
                    </div>
                    <div className="price-filters">
                        <div className="price-range">
                            <input 
                                type="number" 
                                name="minPrice"
                                placeholder="Цена от"
                                value={searchData.minPrice}
                                onChange={handleChange}
                            />
                            <input 
                                type="number" 
                                name="maxPrice"
                                placeholder="Цена до"
                                value={searchData.maxPrice}
                                onChange={handleChange}
                            />
                        </div>
                    </div>

                    <button type="submit">Поиск</button>
                    </div>
                </form>
        </div>
    );
};

export default SearchForm; 