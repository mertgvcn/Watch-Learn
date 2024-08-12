import { configureStore } from '@reduxjs/toolkit'
import courseReducer from '../features/course/courseSlice'
import { useDispatch } from 'react-redux'

export const store = configureStore({
    reducer: {
        course: courseReducer
    },
})

export type RootState = ReturnType<typeof store.getState>

type AppDispatch = typeof store.dispatch
export const useAppDispatch = useDispatch.withTypes<AppDispatch>()