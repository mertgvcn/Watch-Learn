import React, { useState } from 'react'
//mui components
import { Button, Stack, Typography } from '@mui/material'
//models
import { EnrollCurrentUserInCourse } from '../../../../../../models/paramaterModels/Course/EnrollCurrentUserInCourse'
//helpers
import CourseAPI from '../../../../../../utils/APIs/CourseAPI'
import toast from 'react-hot-toast'
import { useAppDispatch } from '../../../../../../redux/app/store'
import { IsCurrentStudentAttendedToCourse } from '../../../../../../redux/features/currentStudent/thunks'

type PurchasingType = {
    courseId: number,
    price: number,
    isStudentAttendedToCourse: boolean
}

const Purchasing = (props: PurchasingType) => {
    const { courseId, price, isStudentAttendedToCourse } = props
    const dispatch = useAppDispatch()

    const [buttonBlocker, setButtonBlocker] = useState(false)

    const handleBuy = async () => {
        setButtonBlocker(true)

        const enrollCurrentUserInCourseRequest: EnrollCurrentUserInCourse = {
            courseId: courseId
        }
        const response = await CourseAPI.EnrollCurrentUserInCourse(enrollCurrentUserInCourseRequest)

        if (response.status = 200) {
            dispatch(IsCurrentStudentAttendedToCourse(courseId))
            toast.success("Course successfully purchased.")
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
            <Button
                variant='contained'
                onClick={handleBuy}
                disabled={buttonBlocker || isStudentAttendedToCourse}
            >
                {isStudentAttendedToCourse ? "Attended" : "Buy"}
            </Button>
        </Stack>
    )
}

export default Purchasing