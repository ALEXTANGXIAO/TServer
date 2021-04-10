using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    internal interface IEventInfo
    {

    }

    public class EventInfo<T> : IEventInfo
    {
        public Action<T> actions;

        public EventInfo(Action<T> action)
        {
            actions += action;
        }
    }

    public class EventInfo : IEventInfo
    {
        public Action actions;

        public EventInfo(Action action)
        {
            actions += action;
        }
    }

    /// <summary>
    /// 事件中心
    /// </summary>
    public class EventCenter : Singleton<EventCenter>
    {
        //Key    --- 事件名称
        //Value  --- 监听这个事件对应函数的委托
        private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

        //Key    --- 事件名称
        //Value  --- 监听这个事件对应函数的委托
        /* 事件中心的优化
         * Dictionary应该都是Hash算法，其时间复杂度接近O(1)Hash算法也就是将Int或者String映射到实际哈希表里面的下标中，
         * 去取对应的数据。如果说速度影响的话，应该是Int是通过某种函数计算出Hash值，速度较快，而String将会遍历每个字符，
         * 然后通过算法来计算哈希值，并防止碰撞，所以用int事件id来代替string减少计算哈希值的过程达到优化事件中心
         */
        private Dictionary<int, IEventInfo> m_eventDic = new Dictionary<int, IEventInfo>();

        //---------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// 添加事件监听
        /// </summary>
        /// <param name="name">事件的名字</param>
        /// <param name="action">准备用来处理事件的委托函数</param>
        public void AddEventListener<T>(string name, Action<T> action)
        {
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo<T>).actions += action;
            }
            else
            {
                eventDic.Add(name, new EventInfo<T>(action));
            }
        }

        public void AddEventListener(string name, Action action)
        {
            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo).actions += action;
            }
            else
            {
                eventDic.Add(name, new EventInfo(action));
            }
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void RemoveEventListener<T>(string name, Action<T> action)
        {
            if (action == null)
            {
                return;
            }

            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo<T>).actions -= action;
            }
        }

        public void RemoveEventListener(string name, Action action)
        {
            if (action == null)
            {
                return;
            }

            if (eventDic.ContainsKey(name))
            {
                (eventDic[name] as EventInfo).actions -= action;
            }
        }

        /// <summary>
        /// 事件触发
        /// </summary>
        /// <param name="name">触发事件的名字</param>
        public void EventTrigger<T>(string name, T info)
        {
            if (eventDic.ContainsKey(name))
            {
                //直接执行委托eventDic[name]();
                if ((eventDic[name] as EventInfo<T>).actions != null)
                {
                    (eventDic[name] as EventInfo<T>).actions.Invoke(info);
                }
            }
        }

        /// <summary>
        /// 事件触发 无参
        /// </summary>
        /// <param name="name"></param>
        public void EventTrigger(string name)
        {
            if (eventDic.ContainsKey(name))
            {
                //直接执行委托eventDic[name]();
                if ((eventDic[name] as EventInfo).actions != null)
                {
                    (eventDic[name] as EventInfo).actions.Invoke();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 添加事件监听
        /// </summary>
        /// <param name="name">事件的名字</param>
        /// <param name="action">准备用来处理事件的委托函数</param>
        public void AddEventListener<T>(int eventid, Action<T> action)
        {
            if (m_eventDic.ContainsKey(eventid))
            {
                (m_eventDic[eventid] as EventInfo<T>).actions += action;
            }
            else
            {
                m_eventDic.Add(eventid, new EventInfo<T>(action));
            }
        }

        public void AddEventListener(int eventid, Action action)
        {
            if (m_eventDic.ContainsKey(eventid))
            {
                (m_eventDic[eventid] as EventInfo).actions += action;
            }
            else
            {
                m_eventDic.Add(eventid, new EventInfo(action));
            }
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void RemoveEventListener<T>(int eventid, Action<T> action)
        {
            if (action == null)
            {
                return;
            }

            if (m_eventDic.ContainsKey(eventid))
            {
                (m_eventDic[eventid] as EventInfo<T>).actions -= action;
            }
        }

        public void RemoveEventListener(int eventid, Action action)
        {
            if (action == null)
            {
                return;
            }

            if (m_eventDic.ContainsKey(eventid))
            {
                (m_eventDic[eventid] as EventInfo).actions -= action;
            }
        }

        /// <summary>
        /// 事件触发
        /// </summary>
        /// <param name="name">触发事件的名字</param>
        public void EventTrigger<T>(int eventid, T info)
        {
            if (m_eventDic.ContainsKey(eventid))
            {
                //直接执行委托eventDic[name]();
                if ((m_eventDic[eventid] as EventInfo<T>).actions != null)
                {
                    (m_eventDic[eventid] as EventInfo<T>).actions.Invoke(info);
                }
            }
        }

        /// <summary>
        /// 事件触发 无参
        /// </summary>
        /// <param name="name"></param>
        public void EventTrigger(int eventid)
        {
            if (m_eventDic.ContainsKey(eventid))
            {
                //直接执行委托eventDic[name]();
                if ((m_eventDic[eventid] as EventInfo).actions != null)
                {
                    (m_eventDic[eventid] as EventInfo).actions.Invoke();
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------//


        /// <summary>
        /// 清除事件中心
        /// </summary>
        public void Clear()
        {
            eventDic.Clear();
        }
    }

}
