using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class NotificationsManager
	{
		private List<INotificationSender> _senders;

		public NotificationsManager(List<INotificationSender> senders)
		{
			_senders = senders;
		}

		public void SendNotify(string user, string msg, object state = null)
		{
			foreach (var sender in _senders)
			{
				sender.SendNotify(user, msg, state);
			}
		}

		public Task SendNotifyAsync(string user, string msg, object state = null)
		{
			return Task.Factory.StartNew(()=> { var u = user; var m = msg; var s = state;  SendNotify(u, m, s); });
		}
	}

	public interface INotificationSender
	{
		void SendNotify(string user, string msg, object state = null);
	}
}
