import React, { useState } from 'react'
//mui components
import { Button, Stack, Typography } from '@mui/material'
//models
import { EnrollCurrentUserInCourse } from '../../../../../../models/paramaterModels/Course/EnrollCurrentUserInCourse'
//helpers
import CourseAPI from '../../../../../../utils/APIs/CourseAPI'
import toast from 'react-hot-toast'

type PurchasingType = {
    courseId: number,
    price: number
}

const Purchasing = ({ courseId, price }: PurchasingType) => {
    const [buttonBlocker, setButtonBlocker] = useState(false)

    const handleBuy = async () => {
        setButtonBlocker(true)

        const enrollCurrentUserInCourseRequest: EnrollCurrentUserInCourse = {
            courseId: courseId
        }
        const response = await CourseAPI.EnrollCurrentUserInCourse(enrollCurrentUserInCourseRequest)

        if(response.status = 200) {
            toast.success("Login successful")
        }
        else {
            toast.error("Something went wrong...")
        }

        setTimeout(() => {
            setButtonBlocker(false)
        }, 1000)
    }

    return (
        <Stack direction="column" spacing={1} >
            <Typography variant='h6'>{price}TL</Typography>
            <Button variant='contained' onClick={handleBuy} disabled={buttonBlocker}>Buy</Button>
        </Stack>
    )
}

export default Purchasing