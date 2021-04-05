using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolC1218
{
    public class timer
    {
        /*
        ******************************************************************************
        * Constant Definitions
        ******************************************************************************
        */
        public const UInt16 TIMER_ms_tic = 200; // Tick period in milliseconds.

        /*
         ******************************************************************************
         * Enumerations and Structures and Typedefs                          
         ******************************************************************************
         */
        public enum ms_timer_id_type : byte
        {
            PORT1_RX_TIMER = 0,
            PORT1_TX_TIMER,
            PORT1_LOGON_TIMER,
            PORT1_ACK_TIMEOUT_TIMER,
            PORT1_RESPONSE_TIMEOUT_TIMER,
            PORT1_MAX_RESPONSE_TIMEOUT_TIMER,
            NUMBER_OF_MS_TIMERS
        };

        /*===========================================================================*\
         * Callback function type
        \*===========================================================================*/
        public delegate void Callback();

        /*===========================================================================*\
         * Main structure for all timers
        \*===========================================================================*/
        public struct ms_timer_type
        {
            public Boolean running;
            public Boolean expired;
            public UInt32 timer;
            public Callback fptr;
        }

        /*
         ******************************************************************************
         * Global and Const Variable Defining Definitions / Initializations
         ******************************************************************************
         */

        private static System.Windows.Forms.Timer tick_timer = new System.Windows.Forms.Timer();

        /*
         ******************************************************************************
         * Static Variables and Const Variables With File Level Scope
         ******************************************************************************
         */
        static UInt32 TIMER_tick_ms_timer;
        static ms_timer_type[] TIMER_ms_timers = new ms_timer_type[(Byte)ms_timer_id_type.NUMBER_OF_MS_TIMERS];

        /*
         ******************************************************************************
         * Function Definitions
         ******************************************************************************
         */

        /**
         ******************************************************************************
         * \fn void initialize()
         * \brief
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public void initialize()
        {
            tick_timer.Interval = 1;  //interrupt each 1ms
            tick_timer.Tick += new EventHandler(ms_tick_handler);
            tick_timer.Enabled = true;

            TIMER_tick_ms_timer = 0;

            for (Byte i = 0; i < (Byte)ms_timer_id_type.NUMBER_OF_MS_TIMERS; i++)
            {
                TIMER_ms_timers[i].running = false;
                TIMER_ms_timers[i].expired = false;
                TIMER_ms_timers[i].timer = 0;
                TIMER_ms_timers[i].fptr = null_action;
            }
        }
        /**
         ******************************************************************************
         * \fn public UInt32 ms_to_tic(UInt32 ms_time)
         * \brief 
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public UInt32 ms_to_tic(UInt32 ms_time)
        {
            return (ms_time / TIMER_ms_tic);
        }

        /**
         ******************************************************************************
         * \fn void start_ms_timer(Byte timer_id, UInt32 ms_period, Callback function_ptr)
         * \brief 
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public void start_ms_timer(Byte timer_id, UInt32 ms_period, Callback function_ptr)
        {
            UInt32 ticks_period = ms_to_tic(ms_period);

            if ((Byte)ms_timer_id_type.NUMBER_OF_MS_TIMERS > timer_id)
            {
                TIMER_ms_timers[timer_id].running = true;
                TIMER_ms_timers[timer_id].expired = false;
                TIMER_ms_timers[timer_id].timer = TIMER_tick_ms_timer + ticks_period;
                TIMER_ms_timers[timer_id].fptr = function_ptr;

                if (ticks_period == 0x0000)
                {
                    TIMER_ms_timers[timer_id].running = false;
                    TIMER_ms_timers[timer_id].expired = true;
                    TIMER_ms_timers[timer_id].fptr();		        //execute the desired call back function
                }
            }
        }

        /**
         ******************************************************************************
         * \fn bool is_ms_timer_running(Byte timer_id)
         * \brief 
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public Boolean is_ms_timer_running(Byte timer_id)
        {
            return TIMER_ms_timers[timer_id].running;
        }

        /**
        ******************************************************************************
        * \fn bool is_ms_timer_expired(Byte timer_id)
        * \brief 
        *
        * \param
        * \retval
        *
        ******************************************************************************
        */
        public bool is_ms_timer_expired(Byte timer_id)
        {
            return TIMER_ms_timers[timer_id].expired;
        }

        /**
         ******************************************************************************
         * \fn void reset_ms_timer(Byte timer_id)
         * \brief 
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public void reset_ms_timer(Byte timer_id)
        {
            TIMER_ms_timers[timer_id].running = false;
            TIMER_ms_timers[timer_id].expired = false;
            TIMER_ms_timers[timer_id].timer = 0;
            TIMER_ms_timers[timer_id].fptr = null_action;
        }

        /**
         ******************************************************************************
         * \fn UInt32 get_pending_ms_time(Byte timer_id)
         * \brief returns the pending time of a timer
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public UInt32 get_pending_ms_time(Byte timer_id)
        {
            UInt32 pending_time = 0;

            if ((Byte)ms_timer_id_type.NUMBER_OF_MS_TIMERS > timer_id)
            {
                if (TIMER_tick_ms_timer < TIMER_ms_timers[timer_id].timer)
                {
                    pending_time = TIMER_ms_timers[timer_id].timer - TIMER_tick_ms_timer;
                }
            }
            return (pending_time);
        }

        /**
         ******************************************************************************
         * \fn UInt32 get_tic_ms_time()
         * \brief Returns the current tick time
         *
         * \param
         * \retval
         *
         ******************************************************************************
         */
        public UInt32 get_tic_ms_time()
        {
            return TIMER_tick_ms_timer;
        }

        /**
         ******************************************************************************
         * \fn void null_action ()
         * \brief Null action routine
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        public void null_action()
        { }

        /**
         ******************************************************************************
         * \fn void ms_tick_handler(Object source, ElapsedEventArgs e)
         * \brief Tic timer interrupt service routine.
         *
         * \param	None
         * \retval	None
         *
         ******************************************************************************
         */
        private void ms_tick_handler(object sender, EventArgs e)
        {
            Byte i;

            TIMER_tick_ms_timer++;

            for (i = 0; i < (Byte)ms_timer_id_type.NUMBER_OF_MS_TIMERS; i++)
            {
                if (TIMER_ms_timers[i].running == true)
                {
                    if (TIMER_tick_ms_timer >= TIMER_ms_timers[i].timer)
                    {
                        TIMER_ms_timers[i].running = false;
                        TIMER_ms_timers[i].expired = true;
                        TIMER_ms_timers[i].fptr();		//execute the desired call back function
                    }
                }
            }
        }
    }
}
