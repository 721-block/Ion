import React from 'react';
import { Link } from 'react-router-dom';
import './CarFilters.css';

const CarFilters = ({ item }) => {
    return (
        <div class="filters-box">
                <div class="filters-buttons">
                    <form class="filters-form">
                        <div class="filters">
                            <div class="car-filter">
                                <select class="body-type" placeholder="Тип кузова">
                                    <option selected disabled>Тип КПП</option>
                                    <option></option>
                                    <option value="">Седан</option>
                                </select>
                            </div>
                            <div class="car-filter">
                                <select class="body-type">
                                    <option selected disabled>Тип Кузова</option>
                                    <option></option>
                                    <option value="">Механическая</option>
                                </select>
                            </div>
                            <div class="car-filter">
                                <select class="mark-type">
                                    <option selected disabled>Марка авто</option>
                                    <option></option>
                                    <option value="">Lada</option>
                                </select>
                            </div>
                        </div>
                        <div class="price-filters">
                            <div class="price-filter">
                                <p>Цена:</p>
                                    <div class="price-range">
                                        <input type="number" placeholder="От"/>
                                        <input type="number" placeholder="До"/>
                                    </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
    );
};

export default CarFilters;