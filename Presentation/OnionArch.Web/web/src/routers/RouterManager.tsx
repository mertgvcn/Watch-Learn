import React from 'react'
import { BrowserRouter } from "react-router-dom"
//models
import { Roles } from '../models/enumerators/Roles'
//Routes
import RouterAdmin from './RouterAdmin'
import RouterGuest from './RouterGuest'
import RouterStudent from './RouterStudent'
import RouterTeacher from './RouterTeacher'

type RouterManagerPropType = {
    userRole: Roles
}

const RouterManager = ({ userRole }: RouterManagerPropType) => {

    const redirectByRole = () => {
        if (userRole == Roles.Guest)
            return <RouterGuest />
        else if (userRole == Roles.Student)
            return <RouterStudent />
        else if (userRole == Roles.Teacher)
            return <RouterTeacher />
        else if (userRole == Roles.Admin)
            return <RouterAdmin />
    }

    return (
        <BrowserRouter>
            {redirectByRole()}
        </BrowserRouter>
    )
}

export default RouterManager