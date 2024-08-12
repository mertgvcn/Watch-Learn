import React from 'react'
//model
import { CourseViewModel } from '../../../../models/viewModels/CourseViewModel'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
//mui components
import styled from '@emotion/styled'
import { Box, Stack, Typography } from '@mui/material'

const HeaderBox = styled(Box)({
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
    maxWidth: "calc(100% - 400px)",
    height: "100%",
    padding: "2rem 0rem",
    boxSizing: "border-box"
})

type CourseDetailHeaderType = {
    course: CourseViewModel
}

const CourseDetailHeader = ({ course }: CourseDetailHeaderType) => {
    return (
        <HeaderBox>
            <Stack direction="column" spacing={2}>
                <Typography variant='h3'>İngilizce Eğitimi (A1-A2)</Typography>
                <Typography variant='body1'>Bu eğitimde tam 1500 kelime öğretiyoruz. İngilizce öğrenmenin en etkili yolu, profesyonel bir öğretmenden online ingilizce kursu almak. A1-A2 seviyesinde hızlı bir başlangıç yapmak isteyenler hazırladık.</Typography>
            </Stack>

            <Stack direction="row" spacing={0.5} sx={{ alignItems: "center" }}>
                <AccountCircleIcon sx={{ fontSize: 26 }} />
                <Typography variant='subtitle1'>{course.teacher.user.firstName} {course.teacher.user.lastName}</Typography>
            </Stack>
        </HeaderBox>
    )
}

export default CourseDetailHeader